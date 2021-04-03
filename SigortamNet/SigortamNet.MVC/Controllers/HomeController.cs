using FormHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SigortamNet.MVC.Models;
using SigortamNet.MVC.ViewModels;
using System.Diagnostics;

namespace SigortamNet.MVC.Controllers
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
            return View(new VisitorViewModel());
        }

        [HttpPost, FormValidator]
        public IActionResult GetNewBids(VisitorViewModel viewModel)
        {

            return Ok();
        }

        public IActionResult MyBids()
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
