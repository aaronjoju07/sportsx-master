using System;
using System.ComponentModel.DataAnnotations;

namespace studentFreelance.Models
{
    public class Products
    {
        [Key]
        public int productid { get; set; }

        [MaxLength(25)]
        public string productnamec{ get; set; }

        [MaxLength(100)]
        public string  productDesc { get; set; }

        public int quantity { get; set; }

        public int amount { get; set; }

        public string image { get; set; }
    }
}

