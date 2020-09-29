using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Coin> Coins { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(_connectionString);
        }
        
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product {
                        Id = 1,
                        Name = "Mountain Dew",
                        Description = "Безалкогольный сильногазированный прохладительный напиток, " +
                            "торговая марка американской компании PepsiCo",
                        PhotoUrl = "https://upload.wikimedia.org/wikipedia/ru/thumb/b/b3/Mountain_Dew_logo.svg/274px-Mountain_Dew_logo.svg.png",
                        CategoryId = 1,
                        Count = 20,
                        Price = 58,
                        IsAvailable = true
                    },
                    new Product {
                        Id = 2,
                        Name = "Coca-Cola",
                        Description = "Безалкогольный газированный напиток, производимый компанией «The Coca-Cola Company». " +
                            "«Кока-Кола» была признана одним из самых дорогих брендов в мире в 2005—2015 " +
                            "годах в рейтинге международного исследовательского агентства Interbrand",
                        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Coca-Cola_logo.svg/220px-Coca-Cola_logo.svg.png",
                        CategoryId = 1,
                        Count = 20,
                        Price = 61,
                        IsAvailable = true,
                        Weight = 900
                    },
                    new Product {
                        Id = 3,
                        Name = "Mirinda",
                        Description = "Торговая марка, принадлежащая американской компании PepsiCo, " +
                            "безалкогольный сильногазированный прохладительный напиток.",
                        PhotoUrl = "https://upload.wikimedia.org/wikipedia/ru/thumb/3/3b/Mirinda_Logo.png/274px-Mirinda_Logo.png",
                        CategoryId = 1,
                        Count = 20,
                        Price = 60,
                        IsAvailable = true
                    },
                    new Product {
                        Id = 4,
                        Name = "Чипсы Lay's",
                        Description = "бренд разнообразных картофельных чипсов, основанный в 1938 году. " +
                            "Чипсы Lay’s производятся компанией Frito-Lay, принадлежащей PepsiCo Inc. с 1970 года. " +
                            "Другие бренды компании Frito-Lay включают Fritos, Doritos, Ruffles, Cheetos и брецели Rold Gold.",
                        PhotoUrl = "https://upload.wikimedia.org/wikipedia/ru/thumb/c/c3/Lays-logo.gif/71px-Lays-logo.gif",
                        CategoryId = 2,
                        Count = 20,
                        Price = 63,
                        IsAvailable = true
                    },
                    new Product {
                        Id = 5,
                        Name = "Сухарики «Кириешки»",
                        Description = "Сухарики «Кириешки» со вкусом сыра и ветчины, 40 г",
                        PhotoUrl = "https://ru.russianfoodusa.com/images/P/Kirieshki-ham-cheese.jpg",
                        CategoryId = 2,
                        Count = 20,
                        Price = 44,
                        IsAvailable = true
                    },
                    new Product {
                        Id = 6,
                        Name = "Чипсы Pringles",
                        Description = "Чипсы Pringles Xtra со вкусом сметаны и лука и их насыщенный вкус " +
                            "никого не оставит равнодушным. Изготовленные по фирменному рецепту, вкус этих чипсов " +
                            "стал еще более экстраординарным и насыщенным. Идеально подходят для перекуса и прогулки " +
                            "с друзьями. Для тех, кто любит удивлять!",
                        PhotoUrl = "https://upload.wikimedia.org/wikipedia/ru/thumb/7/71/Pringles.svg/64px-Pringles.svg.png",
                        CategoryId = 2,
                        Count = 20,
                        Price = 144,
                        IsAvailable = true
                    },
                    new Product {
                        Id = 7,
                        Name = "Наушники Intro RX-190",
                        Description = "Компактные наушники Intro RX-190 предназначены для использования с мобильными " +
                            "устройствами и портативными акустическими системами. Миниатюрные амбушюры надежно " +
                            "держатся в ухе и эффективно отсекают все внешние звуковые помехи, что позволяет " +
                            "сосредоточиться на музыке. Наушники поддерживают широкий спектр воспроизводимых частот, " +
                            "что позволяет услышать каждую ноту.",
                        PhotoUrl = "https://cdn.svyaznoy.ru/upload/iblock/9cc/4134870.jpg",
                        CategoryId = 3,
                        Count = 20,
                        Price = 199,
                        IsAvailable = true
                    },
                    new Product {
                        Id = 8,
                        Name = "Чипсы Cheetos",
                        Description = "Cheetos - это марка закусок, производимых Frito-Lay, дочерней компанией PepsiCo. Создатель Fritos " +
                        "   Чарльз Элмер Доолин изобрел Cheetos в 1948 году и начал национальное распространение в США.",
                        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Cheetos_logo.svg/220px-Cheetos_logo.svg.png",
                        CategoryId = 2,
                        Count = 20,
                        Price = 124,
                        IsAvailable = true
                    },
                });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory[]
                {
                    new ProductCategory { Id=1, Name="Напитки", Weight = 10},
                    new ProductCategory { Id=2, Name="Закуски", Weight = 20},
                    new ProductCategory { Id=3, Name="Прочее", Weight = 30},
                });
            modelBuilder.Entity<Coin>().HasData(
                new Coin[]
                {
                    new Coin { Id=1, Value=1, Count=100, IsAvailable=true},
                    new Coin { Id=2, Value=2, Count=100, IsAvailable=true},
                    new Coin { Id=3, Value=5, Count=100, IsAvailable=true},
                    new Coin { Id=4, Value=10, Count=100, IsAvailable=true}
                });
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id=1, Login="admin", Password="1234qwer"}
                });
        }
    }
}
