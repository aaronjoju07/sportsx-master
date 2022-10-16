using System;
using System.ComponentModel.DataAnnotations;

namespace studentFreelance.Models
{
    public class spoorts
    {
        [Key]
        public string sportts { get; set; }

        public string? sport_img { get; set; }
    }
}

