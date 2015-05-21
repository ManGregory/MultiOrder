using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiOrderWin.Models
{
    /// <summary>
    /// Семестр
    /// </summary>
    public class Semester
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Начало семестра")]
        public DateTime BeginDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Конец семестра")]
        public DateTime EndDate { get; set; }

        [Required]
        [DisplayName("Номер начальной недели")]
        public int FirstSemesterNumber { get; set; }

        public Semester()
        {
            FirstSemesterNumber = 1;
        }
    }
}
