using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForlogicAutoAvaliacao.Domain.Entities
{
    [Table("Avaliacao")]
    public class Avaliacao : BaseEntity
    {
        [Required]
        [Column("mes_ano")]
        [JsonProperty("mes_ano")]
        public DateTime MesAno { get; set; }

        [Required]
        [Column("nota")]
        [JsonProperty("nota")]
        [Range(0, 10, ErrorMessage = "O valor deve estar entre 0 to 10")]
        public int Nota { get; set; }

        [Required]
        [Column("motivo")]
        [JsonProperty("motivo")]
        [MaxLength(250)]
        public string Motivo { get; set; }
        

        [ForeignKey("Cliente")]
        [Column("id_cliente")]
        [JsonProperty("id_cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

    }
}
