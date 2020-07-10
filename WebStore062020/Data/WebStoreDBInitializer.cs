using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebStore.DAL.Context;

namespace WebStore062020.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB _db;

        public WebStoreDBInitializer(WebStoreDB db) => _db = db;

        public void Initialize()
        {
            var db = _db.Database;

            // Так можно удалить всю БД и создать заново. Пустую.
            //if(db.EnsureDeleted())
            //    if(!db.EnsureCreated())
            //        throw new InvalidOperationException("Ошибка при создании БД");

            db.Migrate();

            // Наполняем данными продукты-бренды-секции если продукты пустые
            if (!_db.Products.Any())
            {
                using (db.BeginTransaction())
                {
                    _db.Sections.AddRange(TestData.Sections);

                    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[TProductSections] ON");
                    _db.SaveChanges();
                    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[TProductSections] OFF");

                    db.CommitTransaction();
                }

                using (db.BeginTransaction())
                {
                    _db.Brands.AddRange(TestData.Brands);

                    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[TProductBrands] ON");
                    _db.SaveChanges();
                    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[TProductBrands] OFF");

                    db.CommitTransaction();
                }

                using (db.BeginTransaction())
                {
                    _db.Products.AddRange(TestData.Products);

                    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[TProducts] ON");
                    _db.SaveChanges();
                    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[TProducts] OFF");

                    db.CommitTransaction();
                }

            }

        }
    }
}
