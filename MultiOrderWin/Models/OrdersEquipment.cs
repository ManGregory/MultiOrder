using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOrderWin.Models
{
    public class OrdersEquipment
    {
        [Browsable(false)]
        public virtual int OrderId { get; set; }
        [Browsable(false)]
        public virtual int EquipmentId { get; set; }
        [Browsable(false)]
        public virtual Order Order { get; set; }

        [DisplayName("Оборудование")]
        public virtual Equipment Equipment { get; set; }
        [DisplayName("Количество")]
        public int Amount { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Equipment.Name);
        }
    }
}
