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
        public Classroom Classroom { get; set; }

        [Browsable(false)]
        public static readonly Equipment Empty = new Equipment { Name = "" };

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
