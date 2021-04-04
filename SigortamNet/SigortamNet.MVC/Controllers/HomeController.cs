using FormHelper;
using Microsoft.AspNetCore.Mvc;
using SigortamNet.Application.Contracts.Operations.Bid;
using SigortamNet.Application.Contracts.Operations.Visitor;
using SigortamNet.MVC.ViewModels;
using System.Threading.Tasks;

namespace SigortamNet.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBidService _bidService;
        private readonly IVisitorService _visitorService;

        public HomeController(IBidService bidService, IVisitorService visitorService)
        {
            _bidService = bidService;
            _visitorService = visitorService;
        }

        public IActionResult Index()
        {
            return View(new VisitorViewModel());
        }

        public IActionResult MyLastBids()
        {
            return View(new MyBidsViewModel());
        }

        [HttpPost, FormValidator]
        public async Task<IActionResult> GetMyLastBids(MyBidsViewModel viewModel)
        {
            var result = await _bidService.GetLastBidsByIdentificationAsync(viewModel.IdentificationNumber);

            if (!result.IsSucceed)
            {
                return FormResult.CreateErrorResult(result.Message);
            }

            return FormResult.CreateSuccessResultWithObject(result.Object);
        }

        [HttpPost]
        public async Task<IActionResult> GetInfoByIdentificationAndPlate(string identification, string plate)
        {
            var visitorInput = new VisitorInput
            {
                IdentificationNumber = identification,
                LicensePlate = plate
            };

            var result = await _visitorService.GetInfoByIdentificationAndPlate(visitorInput);

            return Ok(result);
        }
    }
}
