using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SigortamNet.CSigorta.Models;
using System;
using System.Threading;

namespace SigortamNet.CSigorta.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BidsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
            "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
            "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
            "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
            "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur"
        };

        private readonly ILogger<BidsController> _logger;

        public BidsController(ILogger<BidsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(BidInput input)
        {
            Thread.Sleep(500);

            var rnd = new Random();

            return Ok(new BidDto
            {
                Name = "C Sigorta",
                Logo = "",
                LicensePlate = input.LicensePlate,
                Description = Summaries[rnd.Next(0, Summaries.Length - 1)],
                Price = rnd.Next(2000, 3000)
            });
        }
    }
}
