using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser> 
    {
        public DbSet<Product>Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderItem>OrderItems { get; set; }


        public ApplicationDBContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18, 2)");


            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole()
                    {
                        Id=Guid.NewGuid().ToString(),
                        Name="Admin",
                        NormalizedName="ADMIN",
                        ConcurrencyStamp= Guid.NewGuid().ToString()
                    },

                     new IdentityRole()
                     {
                         Id = Guid.NewGuid().ToString(),
                         Name = "User",
                         NormalizedName = "USER",
                         ConcurrencyStamp = Guid.NewGuid().ToString()
                     }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
