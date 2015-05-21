using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiOrderWin.Models
{
    /// <summary>
    /// Оборудование
    /// </summary>
    public class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Количество")]
        public int Amount { get; set; }

        [Browsable(false)]
        public int? ClassroomId { get; set; }
        [DisplayName("Аудитория")]
        [ForeignKey("ClassroomId")]
        public virtual Classroom Classroom { get; set; }

        [Browsable(false)]
        public virtual ICollection<OrdersEquipment> OrdersEquipment { get; set; }

        [Browsable(false)]
        public static readonly Equipment Empty = new Equipment { Name = "" };

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
