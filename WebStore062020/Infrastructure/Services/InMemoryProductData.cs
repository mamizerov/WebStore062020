using System.Collections.Generic;
using System.Linq;
using WebStore062020.Data;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore062020.Infrastructure.Interfaces;
using System;

namespace WebStore062020.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Section> GetSections() => TestData.Sections;

        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            return query;
        }

        public Product GetProductById(int id) => TestData.Products.FirstOrDefault(p => p.Id == id);

        public void Edit(Product product)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));

            var db_employee = GetProductById(product.Id);
            if (db_employee is null) return;

            db_employee.Name = product.Name;
            db_employee.Order = product.Order;
            db_employee.Price = product.Price;
            db_employee.Section = product.Section;
            db_employee.SectionId = product.SectionId;
        }

        public void SaveChanges() { }
    }
}
