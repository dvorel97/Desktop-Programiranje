using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace lab10
{
    public partial class NotesModel : DbContext
    {
        public NotesModel()
            : base("name=NotesModel")
        {
        }

        public virtual DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
