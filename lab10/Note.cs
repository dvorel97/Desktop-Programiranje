using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Xml.Serialization;


namespace lab10
{

    [XmlRoot("note")]
    public partial class Note
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("content")]
        public string Content { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
