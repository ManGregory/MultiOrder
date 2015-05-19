using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOrderWin.Models
{
    class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Дата подачи заявки")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("С какой пары")]
        public int FromPair { get; set; }

        [Required]
        [DisplayName("До какой пары")]
        public int ToPair { get; set; }

        [DisplayName("Аудитория")]
        public virtual Classroom Classroom { get; set; }

        [DisplayName("Пользователь")]
        public virtual User User { get; set; }

        [DisplayName("Оборудование")]
        public virtual Equipment Equipment { get; set; }

        [Browsable(false)]
        public int Amount { get; set; }

        [Browsable(false)]
        public bool IsSigned { get; set; }

        [DisplayName("Период")]
        public string Period { get; set; }
    }
}
