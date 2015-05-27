using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using MultiOrderWin.Extensions;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    /// <summary>
    /// Вспомогательный класс для работы с базой
    /// </summary>
    public static class DbHelper
    {
        /// <summary>
        /// Получение доступного оборудования для указанной пары
        /// </summary>
        /// <param name="pair">Номер пары</param>
        /// <param name="date">Дата</param>
        /// <param name="db">База</param>
        /// <returns>Список доступного оборудования</returns>
        public static IEnumerable<Equipment> GetAvailableEquipment(int pair, DateTime date, MediaContext db)
        {
            /*var equipments = db.Database.SqlQuery<Equipment>(
                "select a.Id, a.Name, a.ClassroomId, " +
                "	(case " +
                "		when a.OrderedAmount is Null then a.Amount " +
                "		else a.Amount - a.OrderedAmount  " +
                "	end) as Amount " +
                "from " +
                "	(select e.Id, e.Name, e.ClassroomId, e.Amount, " +
                "		(select sum(oe.Amount) " +
                "		from OrdersEquipments as oe " +
                "			join Orders as o on oe.OrderId = o.Id and o.IsSigned = 1 and cast(o.[Date] as Date) = @date and @pair between o.FromPair and o.ToPair " +
                "		where oe.EquipmentId = e.Id) as OrderedAmount " +
                "	from Equipments as e where e.ClassroomId is null) as a",
                new SqlParameter("@date", date.Date),
                new SqlParameter("@pair", pair));
            return equipments.ToList();*/
            return GetAvailableEquipment(pair, pair, date, db);
        }

        /// <summary>
        /// Получение доступного оборудования для указанного диапазона оборудования
        /// </summary>
        /// <param name="fromPair">С какой пары</param>
        /// <param name="toPair">По какую пару</param>
        /// <param name="date">Дата</param>
        /// <param name="db">База</param>
        /// <returns>Cписок доступного оборудования</returns>
        public static IEnumerable<Equipment> GetAvailableEquipment(int fromPair, int toPair, DateTime date,
            MediaContext db)
        {
            var equipments = db.Database.SqlQuery<Equipment>(
                "select a.Id, a.Name, a.ClassroomId,  " +
                "    (case " +
                "        when a.OrderedAmount is Null then a.Amount " +
                "        else a.Amount - a.OrderedAmount  " +
                "     end) as Amount " +
                "from " +
                "    (select e.Id, e.Name, e.ClassroomId, e.Amount, " +
                "        (select max(b.am) " +
                "        from  " +
                "            (select sum(oe.Amount) am " +
                "            from OrdersEquipments oe  " +
                "                join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and cast(o.[Date] as Date) = @date and ((@fromPair between o.FromPair and o.ToPair) or (@toPair between o.FromPair and o.ToPair)) " +
                "            where oe.EquipmentId = e.Id ) as b) as OrderedAmount " +
                "    from Equipments e) a " +
                "where a.ClassroomId is null",
                new SqlParameter("@date", date.Date),
                new SqlParameter("@fromPair", fromPair),
                new SqlParameter("@toPair", toPair));
            return equipments.Where(e => e.Amount > 0).ToList();
        }

        /// <summary>
        /// Отчет о количество заявок пользователей в разрезе месяцов
        /// </summary>
        /// <param name="year"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IEnumerable<OrderUser> GetUsersOrderInMonths(int year, MediaContext db)
        {
            List<OrderUser> usersOrder = db.Database.SqlQuery<OrderUser>(
                "select DATEPART(MONTH, o.Date) as month, u.Name, count(o.Id) as count " +
                "from Orders o " +
                "   join Users u on u.Id = o.UserId " +
                "where " +
                "   o.IsSigned = 1 and DATEPART(YEAR, o.Date) = @year " +
                "group by DATEPART(MONTH, o.Date), u.Name ",
                new SqlParameter("@year", year)).ToList();
            return usersOrder;
        }

        /// <summary>
        /// Получение номера недели в году
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Номер недели в году</returns>
        private static int WeekOfYearISO8601(DateTime date)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Получение номера учебной недели для указанной даты
        /// </summary>
        /// <param name="date"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static int GetWeekNumber(DateTime date, MediaContext db)
        {
            var resultWeekNum = 1;
            var semester =
                db.Semesters.FirstOrDefault(s => s.BeginDate <= date && date <= s.EndDate);
            if (semester != null)
            {
                var beginWeekNum = WeekOfYearISO8601(semester.BeginDate);
                var dateWeekNum = WeekOfYearISO8601(date);
                if ((dateWeekNum - beginWeekNum)%2 == 0)
                {
                    resultWeekNum = semester.FirstSemesterNumber;
                }
                else
                {
                    resultWeekNum = semester.FirstSemesterNumber == 1 ? 2 : 1;
                }
            }
            return resultWeekNum;
        }

        /// <summary>
        /// Добавление нескольких заявок (месяц, семестр)
        /// </summary>
        /// <param name="order">Заявка-родитель</param>
        /// <param name="beginDate">С какой даты</param>
        /// <param name="endDate">По какую дату</param>
        /// <param name="db">База</param>
        public static void AddMultipleOrders(Order order, DateTime beginDate, DateTime endDate, MediaContext db)
        {
            var date = beginDate;
            while (date <= endDate)
            {
                var weekNum = GetWeekNumber(date, db);
                // если номер недели совпадает с номером недели заявки или это заявка на обе недели
                if (weekNum == order.Week || order.Week == 0)
                {
                    // создаем новую заявку
                    var newOrder = new Order
                    {
                        ParentId = order.Id,
                        ClassroomId = order.ClassroomId,
                        Date = date,
                        FromPair = order.FromPair,
                        ToPair = order.ToPair,
                        IsSigned = order.IsSigned,
                        Period = order.Period,
                        WeekNumber = order.WeekNumber,
                        OrdersEquipment = new EntityCollection<OrdersEquipment>(),
                        UserId = order.UserId,
                        PersonalEquipment = order.PersonalEquipment
                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    // добавляем оборудование в новую заявку
                    foreach (var orderEquipment in order.OrdersEquipment)
                    {
                        newOrder.OrdersEquipment.Add(new OrdersEquipment
                        {
                            Amount = orderEquipment.Amount,
                            EquipmentId = orderEquipment.EquipmentId,
                            OrderId = newOrder.Id
                        });
                        db.SaveChanges();
                    }
                }
                date = date.AddDays(7);
            }
        }

        /// <summary>
        /// Получение строки заявляемого оборудования на указанную дату и пару
        /// </summary>
        /// <param name="date">Дата заявки</param>
        /// <param name="pairNum">Номер пары</param>
        /// <returns>Строка с перечислением заявляемого оборудования и его количества</returns>
        private static string GetOrders(DateTime date, int pairNum)
        {
            var ordersText = new StringBuilder();
            using (var db = new MediaContext())
            {
                // выбираем все заявки
                var orders = db.Orders
                    .Select(o => o)
                    .Include(o => o.Classroom).Include(o => o.User).ToList()
                    .Where(o => o.IsSigned && pairNum >= o.FromPair && pairNum <= o.ToPair && o.Date.Date == date.Date)
                    .ToList();
                foreach (var o in orders)
                {
                    // добавляем оборудование и количество из заявки
                    ordersText.AppendFormat("{0} ({1})<br />", o.Classroom.Name,
                        string.Join(", ",
                            db.OrdersEquipments.Where(oe => oe.OrderId == o.Id)
                                .Include(oe => oe.Equipment)
                                .ToList()
                                .Select(oe => string.Format("{0}: {1}", oe.Equipment.Name, oe.Amount))));
                }
            }
            return ordersText.ToString();
        }

        /// <summary>
        /// Получение строки таблицы графика на неделю
        /// </summary>
        /// <param name="fromDate">Дата</param>
        /// <param name="pairNum">Номер пары</param>
        /// <returns></returns>
        private static string GetRow(DateTime fromDate, int pairNum)
        {
            var sb = new StringBuilder(string.Format("{0}", "<tr>"));
            sb.AppendFormat("{1}{0}{2}", 
                pairNum == 0 ? "Пара" : pairNum.ToString(),
                pairNum == 0 ? "<th>" : "<td>",
                pairNum == 0 ? "</th>" : "</td>");
            // С начала недели
            var date = fromDate.StartOfWeek(DayOfWeek.Monday);
            while (date <= fromDate.EndOfWeek(DayOfWeek.Monday))
            {
                sb.AppendFormat("{1}{0}&nbsp{2}", 
                    pairNum == 0 ? date.ToShortDateString() : GetOrders(date, pairNum),
                    pairNum == 0 ? "<th>" : "<td>",
                    pairNum == 0 ? "</th>" : "</td>");
                date = date.AddDays(1);
            }
            sb.AppendFormat("{0}", "</tr>");
            return sb.ToString();
        }

        /// <summary>
        /// Заголовок таблицы
        /// </summary>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        private static string GetCaption(DateTime fromDate)
        {
            return string.Format("<caption>Учебная неделя № {0}, с {1} по {2}</caption>",
                GetWeekNumber(fromDate, new MediaContext()),
                fromDate.StartOfWeek(DayOfWeek.Monday).ToShortDateString(),
                fromDate.EndOfWeek(DayOfWeek.Monday).ToShortDateString());
        }

        /// <summary>
        /// Формирование графика заявок на неделю
        /// </summary>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        private static string GetWeekTable(DateTime fromDate)
        {
            var sb = new StringBuilder(string.Format("<table border='1'>{0}", GetCaption(fromDate)));
            const int pairsNum = 5;
            for (var i = 0; i <= pairsNum; i++)
            {
                sb.AppendFormat(GetRow(fromDate, i));
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        /// <summary>
        /// Стили таблицы
        /// </summary>
        /// <returns></returns>
        private static string GetStyle()
        {
            return "<style type='text/css'>body {font-family: Tahoma; } td, th {padding: 5px;} table {font-size: 11pt;}</style>";
        }

        /// <summary>
        /// Заголовок HTML документа
        /// </summary>
        /// <returns></returns>
        private static string GetBeginHeader()
        {
            return string.Format("<html><head>{0}</head><body>", GetStyle());
        }

        /// <summary>
        /// Окончание HTML документа
        /// </summary>
        /// <returns></returns>
        private static string GetEndHeader()
        {
            return "</body></html>";
        }

        /// <summary>
        /// Формирование документа графика заявок на неделю
        /// </summary>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        private static string GetWeekChart(DateTime fromDate)
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetBeginHeader());
            sb.AppendLine(GetWeekTable(fromDate));
            sb.AppendLine(GetEndHeader());
            return sb.ToString();
        }

        /// <summary>
        /// Формирование документа графика заявок на месяц
        /// </summary>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        private static string GetMonthChart(DateTime fromDate)
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetBeginHeader());
            // первый день месяца
            var beginDate = new DateTime(fromDate.Year, fromDate.Month, 1);
            // последний день месяца
            var endDate = new DateTime(fromDate.Year, fromDate.Month,
                DateTime.DaysInMonth(fromDate.Year, fromDate.Month));
            var date = beginDate;
            while (date <= endDate)
            {
                sb.AppendLine(GetWeekTable(date));
                sb.AppendLine("</br>");
                date = date.AddDays(7);
            }
            sb.AppendLine(GetEndHeader());
            return sb.ToString();
        }

        /// <summary>
        /// Формирование графика заявок на семестр
        /// </summary>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        private static string GetSemesterChart(DateTime fromDate)
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetBeginHeader());
            // выбираем семестр в который входит дату
            var semester = new MediaContext().Semesters.FirstOrDefault(s => fromDate >= s.BeginDate && fromDate <= s.EndDate);
            if (semester != null)
            {
                // начало семестра
                var beginDate = semester.BeginDate;
                // конец семестра
                var endDate = semester.EndDate;
                var date = beginDate;
                while (date <= endDate)
                {
                    sb.AppendLine(GetWeekTable(date));
                    sb.AppendLine("</br>");
                    date = date.AddDays(7);
                }
            }            
            sb.AppendLine(GetEndHeader());
            return sb.ToString();            
        }

        /// <summary>
        /// Формирование графика мультимедиа заявок на указанный период
        /// </summary>
        /// <param name="period">Период (неделя, месяц, семестр)</param>
        /// <param name="fromDate">Дата</param>
        /// <returns>HTML документ представляющий график мультимедиа заявок</returns>
        public static string GetOrderChart(int period, DateTime fromDate)
        {
            if (period == 0) return GetWeekChart(fromDate);
            if (period == 1) return GetMonthChart(fromDate);
            return GetSemesterChart(fromDate);
        }
    }

    public class OrderUser 
    {
        [DisplayName("Пользователь")]
        public string Name { get; set; }

        [DisplayName("Месяц")]
        public string MonthName
        {
            get
            {
                return CultureInfo.GetCultureInfoByIetfLanguageTag("ru")
                    .DateTimeFormat.MonthNames[Month - 1];
            }
        }

        [Browsable(false)]
        public int Month { get; set; }
        [DisplayName("Количество заявок")]
        public int Count { get; set; }
    }
}
