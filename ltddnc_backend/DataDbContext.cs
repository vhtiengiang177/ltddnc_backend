using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace ltddnc_backend
{
    public class DataDbContext : DbContext
    {
        public DataDbContext()
        {
        }

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity => {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Email)
                        .IsUnique();

                entity.HasOne<Role>(e => e.Role)
                        .WithMany(role => role.Accounts)
                        .HasForeignKey(e => e.IdRole);

                entity.HasOne<User>(e => e.User)
                      .WithOne(user => user.Account)
                      .HasForeignKey<User>(customer => customer.IdAccount)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Cart>(entity => {
                entity.HasKey(e => new { e.IdUser, e.IdProduct });

                entity.HasOne<User>(e => e.User)
                    .WithMany(c => c.Carts)
                    .HasForeignKey(e => e.IdUser);
            });

            modelBuilder.Entity<Category>(entity => {
                entity.HasKey(e => e.Id);

                entity.HasMany<Product>(e => e.Products)
                      .WithOne(product => product.Category)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.IdAccount);

                //entity.HasMany<Review>(e => e.Reviews)
                //       .WithOne(review => review.User)
                //       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderDetail>(entity => {
                entity.HasKey(e => new { e.IdOrder, e.IdProduct });

                entity.HasOne<Order>(e => e.Order)
                       .WithMany(order => order.OrderDetails)
                       .HasForeignKey(e => e.IdOrder)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Product>(entity => {
                entity.HasKey(e => e.Id);

                entity.HasOne<Category>(e => e.Category)
                        .WithMany(category => category.Products)
                        .HasForeignKey(e => e.IdCategory);

                entity.HasMany<Review>(e => e.Reviews)
                        .WithOne(review => review.Product)
                        .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Review>(entity => {
                entity.HasKey(e => new { e.Id });

                entity.HasOne<Product>(e => e.Product)
                    .WithMany(f => f.Reviews)
                    .HasForeignKey(e => e.IdProduct);

                entity.HasOne<User>(e => e.User)
                    .WithMany(f => f.Reviews)
                    .HasForeignKey(e => e.IdUser);

                entity.HasOne<Order>(e => e.Order)
                    .WithMany(f => f.Reviews)
                    .HasForeignKey(e => e.IdOrder);
            });


            modelBuilder.Entity<Role>(entity => {
                entity.HasKey(e => e.Id);
                entity.HasMany<Account>(e => e.Accounts)
                        .WithOne(account => account.Role)
                        .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Favorite>(entity => {
                entity.HasKey(e => new { e.IdUser, e.IdProduct });

                entity.HasOne<User>(e => e.User)
                    .WithMany(f => f.Favorites)
                    .HasForeignKey(e => e.IdUser);
            });

            modelBuilder.Entity<Order>(entity => {
                entity.HasKey(e => new {e.Id });

                entity.HasMany<Review>(e => e.Reviews)
                       .WithOne(review => review.Order)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            SeedData(modelBuilder);
        }
        public void SeedData(ModelBuilder modelBuilder)
        {
            DateTime createdDate = new DateTime(2021, 07, 10);
            DateTime createdDatePayment = new DateTime(2021, 11, 10);
            DateTime createdDateShip = new DateTime(2021, 12, 10);
            DateTime createdDateNew = new DateTime(2021, 11, 11);
            DateTime endDate = new DateTime(2022, 7, 15);

            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Admin", State = 1 },
                new Role() { Id = 2, Name = "Staff", State = 1 });

            // password: 123456789Abc!
            modelBuilder.Entity<Account>().HasData(
                new Account() { Id = 1, Email = "Admin@gmail.com", Password = "4bb0a94f21769c3b9d68cd8256a87104", State = 1, IdRole = 1 },
                new Account() { Id = 2, Email = "Admin2@gmail.com", Password = "4bb0a94f21769c3b9d68cd8256a87104", State = 1, IdRole = 1 },
                new Account() { Id = 3, Email = "Cust@gmail.com", Password = "4bb0a94f21769c3b9d68cd8256a87104", State = 1, IdRole = 1 },
                new Account() { Id = 4, Email = "Cust2@gmail.com", Password = "4bb0a94f21769c3b9d68cd8256a87104", State = 1, IdRole = 1 });

            modelBuilder.Entity<User>().HasData(
                new User() { IdAccount = 1, Name = "Giang", Phone = "0328801234", Address = "282  Nguyễn Duy Trinh, phường Bình Trưng Tây, Quận 2, TP. HCM" },
                new User() { IdAccount = 2, Name = "Thao", Phone = "0328807278", Address = "Số 1 Võ Văn Ngân, TP Thủ Đức, TP. HCM" },
                new User() { IdAccount = 3, Name = "Bao", Phone = "0328807986", Address = "20 Đặng Văn Bi, phường Trường Thọ, TP Thủ Đức" },
                new User() { IdAccount = 4, Name = "Yen", Phone = "0328807938", Address = "23/2 Đường số 8, TP Thủ Đức" });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Burger", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger.png?alt=media&token=d5d6078f-0031-47cb-83ca-cf84c01087f6" },
                new Category() { Id = 2, Name = "Gà Rán", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/chicken.png?alt=media&token=834b99a6-154f-473f-8211-f0ac62729c9b" },
                new Category() { Id = 3, Name = "Mì Ý", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/pasta.png?alt=media&token=e16f504a-6f46-4a83-bae3-670670a16220" },
                new Category() { Id = 4, Name = "Thức Uống", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/soft-drink.png?alt=media&token=c9193527-5b37-4085-aaa3-21cd8e9bc933" },
                new Category() { Id = 5, Name = "Kem", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=3f35c767-b6d7-4dff-ac2f-826227345841" });

            modelBuilder.Entity<Product>().HasData(
              new Product() { Id = 1, Name = "Gà sốt đậu", Description = "Gà sốt với đậu", State = 1, IdCategory = 2, UnitPrice = 38000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-sot-dau.jpg?alt=media&token=168bac33-bfc6-445b-86cb-4b8b34410808", CreatedDate = new DateTime(2020, 10, 5) },
              new Product() { Id = 2, Name = "Gà sốt H&S", Description = "Gà sốt H&S", State = 1, IdCategory = 2, UnitPrice = 38000, CreatedDate = new DateTime(2022, 2, 5) },
              new Product() { Id = 3, Name = "Burger Mozzarella", Description = "Burger Mozzarella", State = 1, IdCategory = 1, UnitPrice = 50000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-mozzarella.jpg?alt=media&token=3347cfdb-aea4-4008-8ec2-ddaad4f58000", CreatedDate = new DateTime(2020, 12, 5) },
              new Product() { Id = 4, Name = "Burger Double Double", Description = "Burger Double Double", State = 1, IdCategory = 1, UnitPrice = 60000, CreatedDate = new DateTime(2022, 1, 2) },
              new Product() { Id = 5, Name = "Mì Ý", Description = "Mì Ý", State = 1, IdCategory = 3, UnitPrice = 35000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y.jpg?alt=media&token=f31dd329-e97c-4a27-8c6a-24462a1ff050", CreatedDate = new DateTime(2022, 2, 18) },
              new Product() { Id = 6, Name = "Mì Ý Thịt Bò", Description = "Mì Ý Thịt Bò", State = 1, IdCategory = 3, UnitPrice = 40000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y-thit-bo.jpg?alt=media&token=c4bcc54f-2810-4079-a499-8f2622585454", CreatedDate = new DateTime(2022, 8, 20) },
              new Product() { Id = 7, Name = "7Up", Description = "Nước ngọt có ga 7Up", State = 1, IdCategory = 4, UnitPrice = 15000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/7up.jpg?alt=media&token=b84b0fed-f68b-486c-b67d-5b989f54609f", CreatedDate = new DateTime(2021, 10, 25) },
              new Product() { Id = 8, Name = "Nước Cam", Description = "Nước Cam", State = 1, IdCategory = 4, UnitPrice = 18000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/nuoc-cam.jpg?alt=media&token=e195a521-278b-450f-8027-69164bfeae1b", CreatedDate = new DateTime(2021, 3, 5) },
              new Product() { Id = 9, Name = "Burger Bulgogi", Description = "Burger Bulgogi", State = 1, IdCategory = 1, UnitPrice = 45000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-bulgogi.jpg?alt=media&token=e387c83a-c0c8-454a-91c3-f374a32e9411", CreatedDate = new DateTime(2020, 2, 5) },
              new Product() { Id = 10, Name = "Burger Gà Thượng Hạng", Description = "Burger Gà Thượng Hạng", State = 1, IdCategory = 1, UnitPrice = 60000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-ga.jpg?alt=media&token=377b21ad-58af-42b6-82c6-5951930f1a10", CreatedDate = new DateTime(2021, 3, 5) },
              new Product() { Id = 11, Name = "Burger Tôm", Description = "Burger nhân tôm", State = 1, IdCategory = 1, UnitPrice = 60000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-tom-cua.jpg?alt=media&token=abffb82e-2d47-420b-9d64-fa77325ec7db", CreatedDate = new DateTime(2020, 4, 10) },
              new Product() { Id = 12, Name = "Gà sốt phô mai", Description = "Gà chiên giòn phủ lớp phô mai béo ngậy", State = 1, IdCategory = 2, UnitPrice = 60000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-phomai.png?alt=media&token=724597ab-d4f5-4583-b35a-a8538cd5d8b5", CreatedDate = new DateTime(2022, 2, 8) },
              new Product() { Id = 13, Name = "Gà sốt buffalo", Description = "Gà buffalo", State = 1, IdCategory = 2, UnitPrice = 68000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-buffalo.jpg?alt=media&token=355a579e-9f76-4af2-bb8c-11cdf715751e", CreatedDate = new DateTime(2022, 2, 8) },
              new Product() { Id = 14, Name = "Burger cá", Description = "Burger cá", State = 1, IdCategory = 1, UnitPrice = 48000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-ca.png?alt=media&token=4246454a-83d3-4cb6-acac-e663a8c2af1d", CreatedDate = new DateTime(2022, 2, 10) },
              new Product() { Id = 15, Name = "Burger bò teriyaki", Description = "Burger bò terayaki", State = 1, IdCategory = 1, UnitPrice = 50000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-bo-teriyaki.png?alt=media&token=1b014618-e31a-4d0d-97e2-617d3f242315", CreatedDate = new DateTime(2022, 2, 11) },
              new Product() { Id = 16, Name = "Burger phô mai", Description = "Burger phô mai", State = 1, IdCategory = 1, UnitPrice = 50000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-phomai.png?alt=media&token=47f66d33-d901-4a06-a243-c3ac564d92f7", CreatedDate = new DateTime(2021, 2, 11) },
              new Product() { Id = 17, Name = "Burger bò nướng Whopper", Description = "Burger bò nướng whopper", State = 1, IdCategory = 1, UnitPrice = 115000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/16-burgerwhopper_2.jpg?alt=media&token=d65d4da1-dbce-4627-b18d-cb716de0a3e5", CreatedDate = new DateTime(2022, 2, 12) },
              new Product() { Id = 18, Name = "Burger 2 miếng bò", Description = "Burger 2 miếng bò phủ phô mai", State = 1, IdCategory = 1, UnitPrice = 85000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/2-mieng-bo-burger-phomai.jpg?alt=media&token=a0e4ce1f-96c0-417a-9749-4ae0a9b60659", CreatedDate = new DateTime(2022, 2, 10) },
              new Product() { Id = 19, Name = "Burger bò nướng khoai tây", Description = "Burger bò nướng khoai tây lát", State = 1, IdCategory = 1, UnitPrice = 65000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/10-burger-khoai-tay-lat_1.jpg?alt=media&token=20bbb62d-f4a5-4b03-ab3e-ebee8c87c052", CreatedDate = new DateTime(2022, 2, 10) },
              new Product() { Id = 20, Name = "Kem vani", Description = "Kem vani", State = 1, IdCategory = 5, UnitPrice = 28000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/kemvani.jpg?alt=media&token=517fe0ed-4d7c-4bc0-99a6-cb51b36cf63d", CreatedDate = new DateTime(2021, 2, 10) },
              new Product() { Id = 21, Name = "Kem dâu", Description = "Kem dâu", State = 1, IdCategory = 5, UnitPrice = 35000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/kemdau.jpg?alt=media&token=b57f6b9b-d395-458b-8614-decb1c2f4a6e", CreatedDate = new DateTime(2021, 2, 10) },
              new Product() { Id = 22, Name = "Kem cuộn thái lan", Description = "Kem cuộn thái lan", State = 1, IdCategory = 5, UnitPrice = 35000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/kem-cuon-thai-lan.jpg?alt=media&token=a5404ad2-d105-489c-8028-a4baa582e50d", CreatedDate = new DateTime(2021, 2, 10) },
              new Product() { Id = 23, Name = "Nước suối", Description = "Nước suối", State = 1, IdCategory = 4, UnitPrice = 20000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/nuoc-loc.jpg?alt=media&token=7251e6b9-db6f-4a80-a2e5-7bf5cac982d0", CreatedDate = new DateTime(2021, 2, 10) },
              new Product() { Id = 24, Name = "Coca cola", Description = "Coca cola", State = 1, IdCategory = 4, UnitPrice = 22000, Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/coca.jpg?alt=media&token=f4b46061-5236-4bd7-9e9f-bdcda2385fbf", CreatedDate = new DateTime(2021, 2, 10) });

            //modelBuilder.Entity<Cart>().HasData(
            //   new Cart() { IdUser = 3, IdProduct = 1, Quantity = 5 },
            //   new Cart() { IdUser = 3, IdProduct = 3, Quantity = 3 },
            //   new Cart() { IdUser = 3, IdProduct = 11, Quantity = 2 },
            //   new Cart() { IdUser = 3, IdProduct = 2, Quantity = 2 },
            //   new Cart() { IdUser = 3, IdProduct = 5, Quantity = 2 });

            //modelBuilder.Entity<Review>().HasData(
            //   new Review() { Id = 1, IdProduct = 1, IdUser = 3, Name = "Bao", Rating = 5, Date = createdDateNew, Comment = "Món ăn ngon, hấp dẫn", Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", IdOrder = 1 },
            //   new Review() { Id = 2, IdProduct = 1, IdUser = 4, Name = "Yen", Rating = 3, Date = createdDateNew, Comment = "Gà ăn ngon nhưng vận chuyển hơi lâu", Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/profilePics?alt=media&token=f9104aaf-8d5e-4e97-bbd6-aaa80dd5bac6", IdOrder = 1 },
            //   new Review() { Id = 3, IdProduct = 2, IdUser = 3, Name = "Bao", Rating = 5, Date = createdDateNew, Comment = "Very Good", Image = "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", IdOrder = 1 });

            //modelBuilder.Entity<Cart>().HasData(
            //   new Cart() { IdUser = 3, IdProduct = 1, Quantity = 20 });

            //modelBuilder.Entity<Favorite>().HasData(
            //   new Favorite() { IdUser = 3, IdProduct = 1 },
            //   new Favorite() { IdUser = 3, IdProduct = 3 },
            //   new Favorite() { IdUser = 4, IdProduct = 1 },
            //   new Favorite() { IdUser = 4, IdProduct = 5 },
            //   new Favorite() { IdUser = 4, IdProduct = 6 });
        }
    }
}
