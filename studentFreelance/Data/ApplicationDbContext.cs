using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using studentFreelance.Models;

namespace studentFreelance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


           // builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        public DbSet<venue> venue { get; set; }


        public DbSet<Products> Products { get; set; }

       // public DbSet<Payment> payments { get; set; }

        public DbSet<Booking> Bookings { get; set; }

 

        public DbSet<sports> sports { get; set; }

        public DbSet<timming> timmings { get; set; }

       

        public DbSet<spoorts> spoorts { get; set; }


        [NotMapped]
        public combine combine { get; set; }

    }



    //internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    //{
    //    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    //    {
    //        builder.Property(u => u.name).HasMaxLength(50);

    //  }
    //}

    
}
