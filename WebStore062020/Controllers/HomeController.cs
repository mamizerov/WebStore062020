using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore062020.Infrastructure.Interfaces;
using WebStore062020.Models;

namespace WebStore062020.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() => View();

//        public IActionResult Blogs() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Checkout() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Error404() => View();


    }
}