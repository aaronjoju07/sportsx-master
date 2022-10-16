using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentFreelance.Models
{
    public class sports
    {
        [Key]
        public int sports_Id { get; set; }

        [ForeignKey("venue")]
        
        public string venue_name { get; set; }

        public  venue venue { get; set; }

        [ForeignKey("spoorts")]
        public string sportts { get; set; }

        public spoorts spoorts { get; set; }

        public string slot_name { get; set; }

        public int amount { get; set; }

        public string userid { get; set; }

        public virtual List<timming> Timmings { get; set; }


    }
}

