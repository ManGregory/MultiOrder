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
    public class Order
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

        [Browsable(false)]
        public int ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        [DisplayName("Аудитория")]
        public Classroom Classroom { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [DisplayName("Пользователь")]
        public User User { get; set; }

        [Browsable(false)]
        public virtual ICollection<OrdersEquipment> OrdersEquipment { get; set; }

        [Browsable(false)]
        public bool IsSigned { get; set; }

        [DisplayName("Период")]
        public string Period { get; set; }

        [DisplayName("Учебная неделя")]
        public string WeekNumber { get; set; }
    }
}
