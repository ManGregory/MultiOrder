using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public static class DbHelper
    {
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
                "                join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and cast(o.[Date] as Date) = @date and o.FromPair >= @fromPair and o.ToPair <= @toPair " +
                "            where oe.EquipmentId = e.Id " +
                "            group by o.FromPair + '-' + o.ToPair) as b) as OrderedAmount " +
                "    from Equipments e) a " +
                "where a.ClassroomId is null",
                new SqlParameter("@date", date.Date),
                new SqlParameter("@fromPair", fromPair),
                new SqlParameter("@toPair", toPair));
            return equipments.Where(e => e.Amount > 0).ToList();
        }
    }
}
