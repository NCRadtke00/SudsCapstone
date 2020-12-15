﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sud.Data;

namespace Sud.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "345e627f-07a1-430e-a3ce-87abec4e1bf4",
                            ConcurrencyStamp = "44f28eb4-7ae0-4d7a-862c-c255bcc70e60",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "cc243066-9d11-4c20-aacc-3b993c78b5ce",
                            ConcurrencyStamp = "9cb62d7f-eba0-47d5-a00f-4f1e0c74a124",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "69347a38-3686-4545-b63c-057d9ff7b1fb",
                            ConcurrencyStamp = "19572308-e607-4a1a-95c5-3575c11618f6",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Sud.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Sud.Models.Clothes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPopularItem")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicesId");

                    b.ToTable("Clothes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg ",
                            IsPopularItem = false,
                            Name = " 50lb bag",
                            Price = 7.0,
                            ServicesId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg",
                            IsPopularItem = true,
                            Name = " 40lb bag",
                            Price = 6.0,
                            ServicesId = 1
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg",
                            IsPopularItem = false,
                            Name = " 30lb bag",
                            Price = 5.0,
                            ServicesId = 1
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg",
                            IsPopularItem = false,
                            Name = " 20lb bag",
                            Price = 4.0,
                            ServicesId = 1
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = " https://4jlaundromat.com/wp-content/uploads/2016/10/shutterstock_250385533.jpg",
                            IsPopularItem = true,
                            Name = " Fold laundry",
                            Price = 2.0,
                            ServicesId = 3
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = " https://www.rexrx.com/_next/static/images/free-delivery-0a4599ba95770c3c93c524d1626e7d76.png",
                            IsPopularItem = false,
                            Name = " Delivery fee",
                            Price = 4.0,
                            ServicesId = 3
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = " https://images.squarespace-cdn.com/content/v1/5e599564293347515fe2eabc/1583701071232-CFTFT5DHM16PJ08P6M6D/ke17ZwdGBToddI8pDm48kEoJmA0Abk1RrrM77uDVNFhZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIecCtomI4OQXCfULyDTUGqI_q-TQiniCLvIy8yIJMAmQKMshLAGzx4R3EDFOm1kBS/rushservice.jpg",
                            IsPopularItem = false,
                            Name = "Same day Rush Service",
                            Price = 20.0,
                            ServicesId = 3
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = " https://images.squarespace-cdn.com/content/v1/5e599564293347515fe2eabc/1583701071232-CFTFT5DHM16PJ08P6M6D/ke17ZwdGBToddI8pDm48kEoJmA0Abk1RrrM77uDVNFhZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIecCtomI4OQXCfULyDTUGqI_q-TQiniCLvIy8yIJMAmQKMshLAGzx4R3EDFOm1kBS/rushservice.jpg ",
                            IsPopularItem = true,
                            Name = "Next day Rush Service",
                            Price = 10.0,
                            ServicesId = 3
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = " https://images.allergybuyersclub.com/img/CD-CO-WLAS-500.jpg ",
                            IsPopularItem = false,
                            Name = " Additional Charge for Down, Silk, and other rare fabrics materials",
                            Price = 5.0,
                            ServicesId = 3
                        },
                        new
                        {
                            Id = 10,
                            ImageUrl = " https://images-na.ssl-images-amazon.com/images/I/814MCsg4BrL._AC_UL1500_.jpg ",
                            IsPopularItem = false,
                            Name = " 2PC SUIT",
                            Price = 10.5,
                            ServicesId = 2
                        },
                        new
                        {
                            Id = 11,
                            ImageUrl = " https://ae01.alicdn.com/kf/H38607873036b479183e42158db72def2A/Cultiseed-Female-Dress-Set-2020-Women-New-Sexy-Strapless-Puff-Sleeve-2pc-Dress-Set-Suits-Ladies.jpg",
                            IsPopularItem = false,
                            Name = " 2PC DRESS",
                            Price = 11.5,
                            ServicesId = 2
                        },
                        new
                        {
                            Id = 12,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQQsevtEvUk7_dBBHP9x8Vwg25ILuQhBVnJUg&usqp=CAU",
                            IsPopularItem = true,
                            Name = "3PC SUIT",
                            Price = 12.5,
                            ServicesId = 2
                        },
                        new
                        {
                            Id = 13,
                            ImageUrl = " https://media.missguided.com/i/missguided/TW423587_01 ",
                            IsPopularItem = false,
                            Name = "BLOUSE (WOMAN’S)",
                            Price = 3.6000000000000001,
                            ServicesId = 2
                        },
                        new
                        {
                            Id = 14,
                            ImageUrl = "https://i.pinimg.com/originals/49/e2/23/49e2230bb5ae873356664aecc253e464.jpg",
                            IsPopularItem = true,
                            Name = "DRESS",
                            Price = 7.7000000000000002,
                            ServicesId = 2
                        },
                        new
                        {
                            Id = 15,
                            ImageUrl = "https://i.etsystatic.com/13385002/r/il/af0dbd/1197944229/il_570xN.1197944229_8bpp.jpg",
                            IsPopularItem = false,
                            Name = "DRESS-FANCY/EVENING",
                            Price = 9.5999999999999996,
                            ServicesId = 2
                        });
                });

            modelBuilder.Entity("Sud.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<bool>("ConfirmDropoff")
                        .HasColumnType("bit");

                    b.Property<bool>("ConfirmPickUp")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Sud.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Sud.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<bool>("ConfirmDropoff")
                        .HasColumnType("bit");

                    b.Property<bool>("ConfirmPickUp")
                        .HasColumnType("bit");

                    b.Property<string>("DropOffDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("PickUpDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Sud.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("ClothesId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClothesId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Sud.Models.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClothesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ClothesId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClothesId = 2,
                            Date = new DateTime(2020, 12, 14, 22, 13, 6, 19, DateTimeKind.Local).AddTicks(6748),
                            Description = "Eveything smelled like a fresh medow, and was folded perfectly.",
                            Grade = 4,
                            Title = "WOW"
                        },
                        new
                        {
                            Id = 2,
                            ClothesId = 3,
                            Date = new DateTime(2020, 12, 14, 22, 13, 6, 22, DateTimeKind.Local).AddTicks(4858),
                            Description = "The guy picked everthing up, and dropped it off 6 hours later.",
                            Grade = 5,
                            Title = "Legen-dry"
                        });
                });

            modelBuilder.Entity("Sud.Models.Services", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Laundry done for you!",
                            Name = "Laundry"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Dry cleaning at your convience!",
                            Name = "DryCleaning"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Miscellaneous fee's.",
                            Name = "Fee's"
                        });
                });

            modelBuilder.Entity("Sud.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("ClothesId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClothesId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sud.Models.Clothes", b =>
                {
                    b.HasOne("Sud.Models.Services", "Services")
                        .WithMany("Clothes")
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sud.Models.Customer", b =>
                {
                    b.HasOne("Sud.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Sud.Models.Employee", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Sud.Models.Order", b =>
                {
                    b.HasOne("Sud.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Sud.Models.OrderDetail", b =>
                {
                    b.HasOne("Sud.Models.Clothes", "Clothes")
                        .WithMany()
                        .HasForeignKey("ClothesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sud.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sud.Models.Reviews", b =>
                {
                    b.HasOne("Sud.Models.Clothes", "Clothes")
                        .WithMany("Reviews")
                        .HasForeignKey("ClothesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Sud.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("Sud.Models.Clothes", "Clothes")
                        .WithMany()
                        .HasForeignKey("ClothesId");
                });
#pragma warning restore 612, 618
        }
    }
}
