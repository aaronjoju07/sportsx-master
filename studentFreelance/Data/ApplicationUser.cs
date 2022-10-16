using System;
using Microsoft.AspNetCore.Identity;

namespace studentFreelance.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string name { get; set; }

        public int ph_number { get; set; }
    }
}

