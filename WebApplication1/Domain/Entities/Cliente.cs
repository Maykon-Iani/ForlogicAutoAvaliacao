using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForlogicAutoAvaliacao.Domain.Entities
{
    [Table("Cliente")]
    public class Cliente : BaseEntity
    {
        [Required]
        [Column("nome")]
        [JsonProperty("nome")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("nome_contato")]
        [JsonProperty("nome_contato")]
        [MaxLength(100)]
        public string NomeContato { get; set; }

        [Column("cnpj")]
        [JsonProperty("cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Column("categoria")]
        [JsonProperty("categoria")]
        [MaxLength(50)]
        public string Categoria { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; }

    }
}
