using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace studentFreelance.Models
{
    public class timming
    {
        [Key]
        public int t_Id { get; set; }

        [ForeignKey("sports")]
        public int sports_Id { get; set; }
        public virtual sports? sports { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime s_date { get; set; }

        [DisplayName("05:00AM")]
        public bool s1 { get; set; } = true;

        [DisplayName("06:00AM")]
        public bool s2 { get; set; } = true;

        [DisplayName("07:00AM")]
        public bool s3 { get; set; } = true;

        [DisplayName("08:00AM")]
        public bool s4 { get; set; } = true;

        [DisplayName("09:00AM")]
        public bool s5 { get; set; } = true;

        [DisplayName("10:00AM")]
        public bool s6 { get; set; } = true;

        [DisplayName("11:00AM")]
        public bool s7 { get; set; } = true;

        [DisplayName("12:00AM")]
        public bool s8 { get; set; } = true;

        [DisplayName("01:00PM")]
        public bool s9 { get; set; } = true;

        [DisplayName("02:00PM")]
        public bool s10 { get; set; } = true;

        [DisplayName("03:00PM")]
        public bool s11 { get; set; } = true;

        [DisplayName("04:00PM")]
        public bool s12 { get; set; } = true;

        [DisplayName("05:00PM")]
        public bool s13 { get; set; } = true;

        [DisplayName("06:00PM")]
        public bool s14 { get; set; } = true;

        [DisplayName("07:00PM")]
        public bool s15 { get; set; } = true;

        [DisplayName("08:00PM")]
        public bool s16 { get; set; } = true;

        [DisplayName("09:00PM")]
        public bool s17 { get; set; } = true;

        [DisplayName("10:00PM")]
        public bool s18 { get; set; } = true;

        [DisplayName("11:00PM")]
        public bool s19 { get; set; } = true;
    }
}

