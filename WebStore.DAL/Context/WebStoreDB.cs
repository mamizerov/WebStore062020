using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Orders;

namespace WebStore.DAL.Context
{
    // Консоль диспетчера пакетов
    // 1. Переориентировать её на WebStore.DAL
    // 2. Выполнить Add-Migration Initial -v (-v можно не указвать, verbos -просмотр логов)
    // 3. Выполнить Update-Database

    // public class WebStoreDB : DbContext  //использовалось для генерации таблиц продуктов
    public class WebStoreDB : IdentityDbContext<User, Role, string>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public WebStoreDB(DbContextOptions<WebStoreDB> Options) : base(Options) { }
    }
}
