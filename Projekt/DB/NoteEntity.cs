using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.DB
{
    [Table("NOTES")]
    public class NoteEntity
    {
        [Key]
        [Column("ID")]
        [MaxLength(36)]
        public string Id { get; set; }

        [Column("TITLE")]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Column("CONTENT")]
        public string? Content { get; set; }

        [Column("TYPE")]
        [MaxLength(50)]
        public string? Type { get; set; }

        [Column("CREATED")]
        public DateTime? Created { get; set; }

        [Column("MODIFIED")]
        public DateTime? Modified { get; set; }
    }
}
