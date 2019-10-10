using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;
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

            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);
            var homeviewmodel = new HomeViewModel()
            {
                Title = "Welcome to Edwin Pie shop",
                Pies = pies.ToList()
        };
            return View(pies);
        }
    }
}
