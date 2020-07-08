using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Context
{
    // Консоль диспетчера пакетов
    // 1. Переориентировать её на WebStore.DAL
    // 2. Выполнить Add-Migration Initial -v (-v можно не указвать, verbos -просмотр логов)
    // 3. Выполнить Update-Database
    public class WebStoreDB : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public WebStoreDB(DbContextOptions<WebStoreDB> Options) : base(Options) { }
    }
}
