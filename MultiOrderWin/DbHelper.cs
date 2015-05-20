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
        }
    }
}
