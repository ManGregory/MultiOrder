using System;
using System.Collections.Generic;
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
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int FromPair { get; set; }

        [Required]
        public int ToPair { get; set; }

        public virtual Classroom Classroom { get; set; }

        public virtual User User { get; set; }

        public bool IsSigned { get; set; }

        public string Period { get; set; }
    }
}
