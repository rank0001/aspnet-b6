using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestClass _testClass;

        public HomeController(ILogger<HomeController> logger,ITestClass testClass)
        {
             _logger = logger;
            _testClass = testClass;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("logged information from home index!");
            return View(_testClass);
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("logged information from privacy index!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
