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
                new Category() { Id = 1, Name = "Burger", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger.png?alt=media&token=ca9698cb-e20f-4b4a-8403-9e5605a506b7" },
                new Category() { Id = 2, Name = "Gà Rán", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/chicken.png?alt=media&token=0428fbff-b7e6-4a03-8fb5-6e9c7168fec4" },
                new Category() { Id = 3, Name = "Mì Ý", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/spaghetti.png?alt=media&token=fdeba4a1-a640-4f61-9623-9c2cf50e641d" },
                new Category() { Id = 4, Name = "Thức Uống", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/soft-drink.png?alt=media&token=6e742231-8482-4fec-815a-14a360abbc69" },
                new Category() { Id = 5, Name = "Kem", State = 1, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94" });

            modelBuilder.Entity<Product>().HasData(
              new Product() { Id = 1, Name = "Gà sốt đậu", Description = "Gà sốt với đậu", Stock = 100, State = 1, IdCategory = 2, UnitPrice = 38000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-sot-dau.jpg?alt=media&token=168bac33-bfc6-445b-86cb-4b8b34410808" },
              new Product() { Id = 2, Name = "Gà sốt H&S", Description = "Gà sốt H&S", Stock = 100, State = 1, IdCategory = 2, UnitPrice = 38000 },
              new Product() { Id = 3, Name = "Burger Mozzarella", Description = "Burger Mozzarella", Stock = 100, State = 1, IdCategory = 1, UnitPrice = 50000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-mozzarella.jpg?alt=media&token=3347cfdb-aea4-4008-8ec2-ddaad4f58000" },
              new Product() { Id = 4, Name = "Burger Double Double", Description = "Burger Double Double", Stock = 100, State = 1, IdCategory = 1, UnitPrice = 60000 },
              new Product() { Id = 5, Name = "Mì Ý", Description = "Mì Ý", Stock = 100, State = 1, IdCategory = 3, UnitPrice = 35000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y.jpg?alt=media&token=f31dd329-e97c-4a27-8c6a-24462a1ff050" },
              new Product() { Id = 6, Name = "Mì Ý Thịt Bò", Description = "Mì Ý Thịt Bò", Stock = 100, State = 1, IdCategory = 3, UnitPrice = 40000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y-thit-bo.jpg?alt=media&token=c4bcc54f-2810-4079-a499-8f2622585454" },
              new Product() { Id = 7, Name = "7Up", Description = "Nước ngọt có ga 7Up", Stock = 100, State = 1, IdCategory = 4, UnitPrice = 15000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/7up.jpg?alt=media&token=b84b0fed-f68b-486c-b67d-5b989f54609f" },
              new Product() { Id = 8, Name = "Nước Cam", Description = "Nước Cam", Stock = 100, State = 1, IdCategory = 4, UnitPrice = 18000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/nuoc-cam.jpg?alt=media&token=e195a521-278b-450f-8027-69164bfeae1b" },
              new Product() { Id = 9, Name = "Burger Bulgogi", Description = "Burger Bulgogi", Stock = 100, State = 1, IdCategory = 1, UnitPrice = 45000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-bulgogi.jpg?alt=media&token=e387c83a-c0c8-454a-91c3-f374a32e9411" },
              new Product() { Id = 10, Name = "Burger Gà Thượng Hạng", Description = "Burger Gà Thượng Hạng", Stock = 100, State = 1, IdCategory = 1, UnitPrice = 60000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-ga.jpg?alt=media&token=377b21ad-58af-42b6-82c6-5951930f1a10" },
              new Product() { Id = 11, Name = "Burger Tôm", Description = "Burger nhân tôm", Stock = 100, State = 1, IdCategory = 1, UnitPrice = 60000, Image= "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-tom-cua.jpg?alt=media&token=abffb82e-2d47-420b-9d64-fa77325ec7db" });

            //modelBuilder.Entity<Cart>().HasData(
            //   new Cart() { IdUser = 3, IdProduct = 1, Quantity = 5 },
            //   new Cart() { IdUser = 3, IdProduct = 3, Quantity = 3 },
            //   new Cart() { IdUser = 3, IdProduct = 11, Quantity = 2 },
            //   new Cart() { IdUser = 3, IdProduct = 2, Quantity = 2 },
            //   new Cart() { IdUser = 3, IdProduct = 5, Quantity = 2 });

            //modelBuilder.Entity<Favorite>().HasData(
            //   new Favorite() { IdUser = 3, IdProduct = 1 },
            //   new Favorite() { IdUser = 3, IdProduct = 3 },
            //   new Favorite() { IdUser = 4, IdProduct = 1 },
            //   new Favorite() { IdUser = 4, IdProduct = 5 },
            //   new Favorite() { IdUser = 4, IdProduct = 6 });
        }
    }
}
