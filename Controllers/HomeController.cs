using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerZUwierzytelnieniem.Models;

namespace TaskManagerZUwierzytelnieniem.Controllers
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
            ViewBag.sessionv = HttpContext.Session.GetString("Cytaty");
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult Cytaty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cytaty(string cytat)
        {
            // dodaj do sesji
            string cytaty = HttpContext.Session.GetString("Cytaty");
            cytaty += "<br>" + cytat;
            HttpContext.Session.SetString("Cytaty", cytaty);
            return RedirectToAction("Cytaty");
        }

        public IActionResult My()
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
