using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
             _pieRepository = pieRepository;
        }
   
        public IActionResult Index()
        {
            return View();
        }
    }
}
