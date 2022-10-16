using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentFreelance.Models
{
    public class Payment
    {
        [Key]
        public int payment_Id { get; set; }

        [ForeignKey("Products")]
        public int productid { get; set; }

        public string Id { get; set; }

        //[ForeignKey("timming")]
        //public int t_Id { get; set; }

        public int p_quantity { get; set; }

        public int amount { get; set; }

        public bool payment_status { get; set; } = false;
    }
}

