using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForlogicAutoAvaliacao.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Required]
        [Column("login")]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [Column("senha")]
        [MaxLength(50)]
        public string Senha { get; set; }

        [Required]
        [Column("role")]
        [MaxLength(50)]
        public string Role { get; set; }
    }
}
