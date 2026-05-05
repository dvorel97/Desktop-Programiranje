namespace lab10
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Note
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
