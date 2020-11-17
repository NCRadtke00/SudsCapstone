using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Sud.Models;
using Microsoft.AspNetCore.Identity;

namespace Sud.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            builder.Entity<IdentityRole>()
             .HasData(
             new IdentityRole
             {
                 Name = "Employee",
                 NormalizedName = "EMPLOYEE"
             });
            builder.Entity<IdentityRole>()
             .HasData(
             new IdentityRole
             {
                 Name = "Customer",
                 NormalizedName = "CUSTOMER"
             });
        }
        public DbSet<Services> Services { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
