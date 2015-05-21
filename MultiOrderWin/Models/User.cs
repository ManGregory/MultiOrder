using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiOrderWin.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        [Browsable(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Имя пользователя")]
        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)] 
        public string Name { get; set; }

        [DisplayName("Пароль")]
        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [DisplayName("Админ")]
        public bool IsAdmin { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
