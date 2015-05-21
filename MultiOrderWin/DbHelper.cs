using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
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
            var equipments = db.Database.SqlQuery<Equipment>(
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
            return equipments.ToList();
            //return GetAvailableEquipment(pair, pair, date, db);
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
                "                join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and cast(o.[Date] as Date) = @date and (o.FromPair >= @fromPair or o.ToPair <= @toPair) " +
                "            where oe.EquipmentId = e.Id " +
                "            group by o.FromPair + '-' + o.ToPair) as b) as OrderedAmount " +
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
                if (weekNum == order.Week || order.Week == 0)
                {
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
                        UserId = order.UserId
                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();

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
