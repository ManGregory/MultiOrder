using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiOrderWin.Models
{
    /// <summary>
    /// Аудитория
    /// </summary>
    public class Classroom
    {
        [Browsable(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Название аудитории")]
        public string Name { get; set; }

        [Browsable(false)]
        public static readonly Classroom Empty = new Classroom { Name = "" };

        public override string ToString()
        {
            return string.Format("{0} {1}", Name == string.Empty ? string.Empty : "Аудитория", Name);
        }
    }
}
