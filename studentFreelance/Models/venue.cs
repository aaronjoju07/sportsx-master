using System;
using System.ComponentModel.DataAnnotations;

namespace studentFreelance.Models
{
    public class venue
    {
        [Key]
        public string venue_name { get; set; }

        public string Id { get; set; }

        public string venue_desc { get; set; }

        public string venue_pic { get; set; }

        public string venue_location { get; set; } = "";

        public virtual List<sports> Sports { get; set; } = new List<sports>();
        public virtual List<spoorts> Spoorts { get; set; } = new List<spoorts>();


        // public virtual List<timming> Timmings { get; set; }
    }
}

