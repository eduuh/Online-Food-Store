using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class FeedbackController : Controller
    {

        private readonly IFeedbackRepository _feedbackrepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackrepository = feedbackRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index (Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackrepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            return View(feedback);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }


    }
}