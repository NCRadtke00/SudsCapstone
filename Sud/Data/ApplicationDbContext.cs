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
            builder.Entity<Services>()
                .HasData(
                new Services
                {
                    Id = 1,
                    Name = "Laundry",
                    Description = "Laundry done for you!"
                },
                new Services
                {
                    Id = 2,
                    Name = "DryCleaning",
                    Description = "Dry cleaning at your convience!"
                },
                new Services
                {
                    Id = 3,
                    Name = "Fee's",
                    Description = "Miscellaneous fee's."
                });
            builder.Entity<Clothes>()
                .HasData(
                 new Clothes
                 {
                     Id = 1,
                     Name = " 50lb bag",
                     Price = 7.00m,
                     ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg ",
                     IsPopularItem = false,
                     ServicesId = 1
                 },
                new Clothes
                {
                    Id = 2,
                    Name = " 40lb bag",
                    Price = 6.00m,
                    ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg",
                    IsPopularItem = true,
                    ServicesId = 1
                },
                new Clothes
                {
                    Id = 3,
                    Name = " 30lb bag",
                    Price = 5.00m,
                    ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg",
                    IsPopularItem = false,
                    ServicesId = 1
                },
                new Clothes
                {
                    Id = 4,
                    Name = " 20lb bag",
                    Price = 4.00m,
                    ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg",
                    IsPopularItem = false,
                    ServicesId = 1
                },
                new Clothes
                {
                    Id = 5,
                    Name = " Fold laundry",
                    Price = 2.00m,
                    ImageUrl = " https://4jlaundromat.com/wp-content/uploads/2016/10/shutterstock_250385533.jpg",
                    IsPopularItem = true,
                    ServicesId = 3
                },
                new Clothes
                {
                    Id = 6,
                    Name = " Delivery fee",
                    Price = 4.00m,
                    ImageUrl = " https://www.rexrx.com/_next/static/images/free-delivery-0a4599ba95770c3c93c524d1626e7d76.png",
                    IsPopularItem = false,
                    ServicesId = 3
                },
                new Clothes
                {
                    Id = 7,
                    Name = "Same day Rush Service",
                    Price = 20.00m,
                    ImageUrl = " https://images.squarespace-cdn.com/content/v1/5e599564293347515fe2eabc/1583701071232-CFTFT5DHM16PJ08P6M6D/ke17ZwdGBToddI8pDm48kEoJmA0Abk1RrrM77uDVNFhZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIecCtomI4OQXCfULyDTUGqI_q-TQiniCLvIy8yIJMAmQKMshLAGzx4R3EDFOm1kBS/rushservice.jpg",
                    IsPopularItem = false,
                    ServicesId = 3
                },
                new Clothes
                {
                    Id = 8,
                    Name = "Next day Rush Service",
                    Price = 10.00M,
                    ImageUrl = " https://images.squarespace-cdn.com/content/v1/5e599564293347515fe2eabc/1583701071232-CFTFT5DHM16PJ08P6M6D/ke17ZwdGBToddI8pDm48kEoJmA0Abk1RrrM77uDVNFhZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIecCtomI4OQXCfULyDTUGqI_q-TQiniCLvIy8yIJMAmQKMshLAGzx4R3EDFOm1kBS/rushservice.jpg ",
                    IsPopularItem = true,
                    ServicesId = 3
                },
                new Clothes
                {
                    Id = 9,
                    Name = " Additional Charge for Down, Silk, and other rare fabrics materials",
                    Price = 5.00M,
                    ImageUrl = " https://images.allergybuyersclub.com/img/CD-CO-WLAS-500.jpg ",
                    IsPopularItem = false,
                    ServicesId = 3
                },
                new Clothes
                {
                    Id = 10,
                    Name = " 2PC SUIT",
                    Price = 10.50m,
                    ImageUrl = " https://images-na.ssl-images-amazon.com/images/I/814MCsg4BrL._AC_UL1500_.jpg ",
                    IsPopularItem = false,
                    ServicesId = 2
                },
                new Clothes
                {
                    Id = 11,
                    Name = " 2PC DRESS",
                    Price = 11.50m,
                    ImageUrl = " https://ae01.alicdn.com/kf/H38607873036b479183e42158db72def2A/Cultiseed-Female-Dress-Set-2020-Women-New-Sexy-Strapless-Puff-Sleeve-2pc-Dress-Set-Suits-Ladies.jpg",
                    IsPopularItem = false,
                    ServicesId = 2
                },
                new Clothes
                {
                    Id = 12,
                    Name = "3PC SUIT",
                    Price = 12.50m,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQQsevtEvUk7_dBBHP9x8Vwg25ILuQhBVnJUg&usqp=CAU",
                    IsPopularItem = true,
                    ServicesId = 2
                },
                new Clothes
                {
                    Id = 13,
                    Name = "BLOUSE (WOMAN’S)",
                    Price = 3.60m,
                    ImageUrl = " https://media.missguided.com/i/missguided/TW423587_01 ",
                    IsPopularItem = false,
                    ServicesId = 2
                },
                new Clothes
                {
                    Id = 14,
                    Name = "DRESS",
                    Price = 7.70m,
                    ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg",
                    IsPopularItem = true,
                    ServicesId = 2
                },
                new Clothes
                {
                    Id = 15,
                    Name = "DRESS-FANCY/EVENING",
                    Price = 9.60m,
                    ImageUrl = "https://i.etsystatic.com/13385002/r/il/af0dbd/1197944229/il_570xN.1197944229_8bpp.jpg",
                    IsPopularItem = false,
                    ServicesId = 2
                });
            builder.Entity<Order>()
                .HasData(
                new Order
                {
                    OrderId = 1,
                    FirstName = "Nevin",
                    LastName = "Sei",
                    AddressLine1 = "909 E Locust St",
                    AddressLine2 = null,
                    ZipCode = "53212",
                    City = "Milwaukee",
                    State = "Wisconsin",
                    Country = "United State",
                    PhoneNumber = "4142292255",
                    Email = "NevS@gmail.com",
                    OrderTotal = 95.00M,
                    OrderPlaced = DateTime.Now.AddDays(-3),
                },
                new Order
                {
                    OrderId = 2,
                    FirstName = "Nick",
                    LastName = "Jac",
                    AddressLine1 = "1872 N Commerce St",
                    AddressLine2 = null,
                    ZipCode = "53212",
                    City = "Milwaukee",
                    State = "Wisconsin",
                    Country = "United State",
                    PhoneNumber = "4142293030",
                    Email = "NJac@gmail.com",
                    OrderTotal = 20.00M,
                    OrderPlaced = DateTime.Now.AddDays(-3),
                });
            builder.Entity<Reviews>()
                .HasData(
                new Reviews
                {
                    Id = 1,
                    Title = "WOW",
                    Description = "Eveything smelled like a fresh medow, and was folded perfectly.",
                    Grade = 4,
                    Date = DateTime.Now,
                    ClothesId = 2
                },
                new Reviews
                {
                    Id = 2,
                    Title = "Legen-dry",
                    Description = "The guy picked everthing up, and dropped it off 6 hours later.",
                    Grade = 5,
                    Date = DateTime.Now,
                    ClothesId = 3
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
