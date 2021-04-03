using FormHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SigortamNet.Application.Contracts.Operations.Bid;
using SigortamNet.MVC.Models;
using SigortamNet.MVC.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SigortamNet.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBidService _bidService;

        public HomeController(ILogger<HomeController> logger, IBidService bidService)
        {
            _bidService = bidService;
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

        public IActionResult MyLastBids()
        {
            return View(new MyBidsViewModel());
        }

        public async Task<IActionResult> GetMyLastBids(MyBidsViewModel viewModel)
        {
            var result = await _bidService.GetListByIdentificationNumberAsync(viewModel.IdentificationNumber);

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
