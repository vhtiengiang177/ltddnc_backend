﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ltddnc_backend;

namespace ltddnc_backend.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ltddnc_backend.Entity.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("IdRole");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Admin@gmail.com",
                            IdRole = 1,
                            Password = "4bb0a94f21769c3b9d68cd8256a87104",
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Admin2@gmail.com",
                            IdRole = 1,
                            Password = "4bb0a94f21769c3b9d68cd8256a87104",
                            State = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "Cust@gmail.com",
                            IdRole = 1,
                            Password = "4bb0a94f21769c3b9d68cd8256a87104",
                            State = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "Cust2@gmail.com",
                            IdRole = 1,
                            Password = "4bb0a94f21769c3b9d68cd8256a87104",
                            State = 1
                        });
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Cart", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdProduct");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger.png?alt=media&token=ca9698cb-e20f-4b4a-8403-9e5605a506b7",
                            Name = "Burger",
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/chicken.png?alt=media&token=0428fbff-b7e6-4a03-8fb5-6e9c7168fec4",
                            Name = "Gà Rán",
                            State = 1
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/spaghetti.png?alt=media&token=fdeba4a1-a640-4f61-9623-9c2cf50e641d",
                            Name = "Mì Ý",
                            State = 1
                        },
                        new
                        {
                            Id = 4,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/soft-drink.png?alt=media&token=6e742231-8482-4fec-815a-14a360abbc69",
                            Name = "Thức Uống",
                            State = 1
                        },
                        new
                        {
                            Id = 5,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94",
                            Name = "Kem",
                            State = 1
                        });
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Favorite", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdProduct");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<double>("TotalProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("UserIdAccount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserIdAccount");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ltddnc_backend.Entity.OrderDetail", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("IdOrder", "IdProduct");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Gà sốt với đậu",
                            IdCategory = 2,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-sot-dau.jpg?alt=media&token=168bac33-bfc6-445b-86cb-4b8b34410808",
                            Name = "Gà sốt đậu",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 38000.0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Gà sốt H&S",
                            IdCategory = 2,
                            Name = "Gà sốt H&S",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 38000.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Burger Mozzarella",
                            IdCategory = 1,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-mozzarella.jpg?alt=media&token=3347cfdb-aea4-4008-8ec2-ddaad4f58000",
                            Name = "Burger Mozzarella",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 50000.0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Burger Double Double",
                            IdCategory = 1,
                            Name = "Burger Double Double",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 60000.0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Mì Ý",
                            IdCategory = 3,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y.jpg?alt=media&token=f31dd329-e97c-4a27-8c6a-24462a1ff050",
                            Name = "Mì Ý",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 35000.0
                        },
                        new
                        {
                            Id = 6,
                            Description = "Mì Ý Thịt Bò",
                            IdCategory = 3,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y-thit-bo.jpg?alt=media&token=c4bcc54f-2810-4079-a499-8f2622585454",
                            Name = "Mì Ý Thịt Bò",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 40000.0
                        },
                        new
                        {
                            Id = 7,
                            Description = "Nước ngọt có ga 7Up",
                            IdCategory = 4,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/7up.jpg?alt=media&token=b84b0fed-f68b-486c-b67d-5b989f54609f",
                            Name = "7Up",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 15000.0
                        },
                        new
                        {
                            Id = 8,
                            Description = "Nước Cam",
                            IdCategory = 4,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/nuoc-cam.jpg?alt=media&token=e195a521-278b-450f-8027-69164bfeae1b",
                            Name = "Nước Cam",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 18000.0
                        },
                        new
                        {
                            Id = 9,
                            Description = "Burger Bulgogi",
                            IdCategory = 1,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-bulgogi.jpg?alt=media&token=e387c83a-c0c8-454a-91c3-f374a32e9411",
                            Name = "Burger Bulgogi",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 45000.0
                        },
                        new
                        {
                            Id = 10,
                            Description = "Burger Gà Thượng Hạng",
                            IdCategory = 1,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-ga.jpg?alt=media&token=377b21ad-58af-42b6-82c6-5951930f1a10",
                            Name = "Burger Gà Thượng Hạng",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 60000.0
                        },
                        new
                        {
                            Id = 11,
                            Description = "Burger nhân tôm",
                            IdCategory = 1,
                            Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-tom-cua.jpg?alt=media&token=abffb82e-2d47-420b-9d64-fa77325ec7db",
                            Name = "Burger Tôm",
                            State = 1,
                            Stock = 100,
                            UnitPrice = 60000.0
                        });
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Staff",
                            State = 1
                        });
                });

            modelBuilder.Entity("ltddnc_backend.Entity.User", b =>
                {
                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAccount");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            IdAccount = 1,
                            Address = "282  Nguyễn Duy Trinh, phường Bình Trưng Tây, Quận 2, TP. HCM",
                            Name = "Giang",
                            Phone = "0328801234"
                        },
                        new
                        {
                            IdAccount = 2,
                            Address = "Số 1 Võ Văn Ngân, TP Thủ Đức, TP. HCM",
                            Name = "Thao",
                            Phone = "0328807278"
                        },
                        new
                        {
                            IdAccount = 3,
                            Address = "20 Đặng Văn Bi, phường Trường Thọ, TP Thủ Đức",
                            Name = "Bao",
                            Phone = "0328807986"
                        },
                        new
                        {
                            IdAccount = 4,
                            Address = "23/2 Đường số 8, TP Thủ Đức",
                            Name = "Yen",
                            Phone = "0328807938"
                        });
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Account", b =>
                {
                    b.HasOne("ltddnc_backend.Entity.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Cart", b =>
                {
                    b.HasOne("ltddnc_backend.Entity.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Favorite", b =>
                {
                    b.HasOne("ltddnc_backend.Entity.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Order", b =>
                {
                    b.HasOne("ltddnc_backend.Entity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserIdAccount");
                });

            modelBuilder.Entity("ltddnc_backend.Entity.OrderDetail", b =>
                {
                    b.HasOne("ltddnc_backend.Entity.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ltddnc_backend.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ltddnc_backend.Entity.Product", b =>
                {
                    b.HasOne("ltddnc_backend.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ltddnc_backend.Entity.User", b =>
                {
                    b.HasOne("ltddnc_backend.Entity.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("ltddnc_backend.Entity.User", "IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
