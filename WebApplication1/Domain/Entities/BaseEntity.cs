using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForlogicAutoAvaliacao.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public virtual int Id { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
