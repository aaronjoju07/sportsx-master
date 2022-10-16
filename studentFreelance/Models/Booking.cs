using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentFreelance.Models
{
    public class Booking
    {
        [Key]
        public int booking_Id { get; set; }

        public string Id { get; set; }

        public int product_id { get; set; }

        public virtual Products? products { get; set; }
     
        public bool type { get; set; }

        public int amount { get; set; }

        [Range(1,1000)]
        public int  quantity { get; set; }

        public string Address { get; set; }

        public bool payment_status { get; set; } = false;

    }
}

