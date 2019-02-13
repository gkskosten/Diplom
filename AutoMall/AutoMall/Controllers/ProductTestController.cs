using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMall.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMall.Controllers
{
    public class ProductTestController : Controller
    {
        /// <summary>
        /// Список продуктов
        /// </summary>
        private static List<Product> Products { get; set; }
        

        public ProductTestController()
        {
            if (Products == null)
            {
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Тормозной диск",
                        Description = "Тормозной диск",
                        CarModel = "BMV",
                        Identifier = 1
                    },
                    new Product()
                    {
                        Name = "Масляной фильтр",
                        Description = "Масляной фильтр",
                        CarModel = "Mercedes",
                        Identifier = 2
                    },
                    new Product()
                    {
                        Name = "Амартизатор",
                        Description = "Амартизатор",
                        CarModel = "Subaru",
                        Identifier = 3
                    },
                    new Product()
                    {
                        Name = "ABS",
                        Description = "Антиблокировачная система",
                        CarModel = "BMV",
                        Identifier = 4
                    },
                    new Product()
                    {
                        Name = "Топливный фильтр",
                        Description = "Топливный фильтр для дизельных машин",
                        CarModel = "BMV",
                        Identifier = 5
                    }
                };
            }
        }


        // Загрузка 
        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult AddProduct()
        {
            ViewData["Message"] = "Здесь вы можете создать новый продукт.";

            return View();
        }
               
        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {
            ViewData["Message"] = "Your application description page.";

            Products.Add(newProduct);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
