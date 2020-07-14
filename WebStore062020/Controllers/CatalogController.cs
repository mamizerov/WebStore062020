﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore062020.Infrastructure.Interfaces;
using WebStore062020.Infrastructure.Mapping;
using WebStore062020.ViewModels;

namespace WebStore062020.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Shop(int? BrandId, int? SectionId)
        {
            var filter = new ProductFilter
            {
                BrandId = BrandId,
                SectionId = SectionId
            };

            var products = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products.ToView().OrderBy(p => p.Order)
            });
        }
    }
}
