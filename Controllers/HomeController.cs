using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SquareRootChecker.Models;

namespace SquareRootChecker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Index(string FirstNumber, string SecondNumber)
        {
            int NumberOne = int.Parse(FirstNumber);
            int NumberTwo = int.Parse(SecondNumber);

            double SquareOne = Math.Sqrt(NumberOne);
            double SquareTwo = Math.Sqrt(NumberTwo);
            var message = "Welcome";

            if (SquareOne > SquareTwo)
            {
                message = $"The number {NumberOne} with Square root = {SquareOne} has a higher square root than the number {NumberTwo} with square root = {SquareTwo}";
            } 
            else if (SquareTwo > SquareOne)
            {
                message = $"The number {NumberTwo} with Square root = {SquareTwo} has a higher square root than the number {NumberOne} with square root = {SquareOne}";
            } 
            else if (SquareOne == SquareTwo)
            {
                message = $"The both numbers '{NumberOne}' and '{NumberTwo}' have the same Square Root, Please enter another number.."; 
            }

            ViewBag.SquareOne = SquareOne;
            ViewBag.SquareTwo = SquareTwo;
            ViewBag.Message = message;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
