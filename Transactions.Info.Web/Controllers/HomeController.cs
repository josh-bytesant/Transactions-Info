using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Transactions.Info.Web.BL;
using Transactions.Info.Web.Models;

namespace Transactions.Info.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AccountInfoBL _accountInfoBL;

        public HomeController(ILogger<HomeController> logger, AccountInfoBL accountInfoBL)
        {
            _logger = logger;
            _accountInfoBL = accountInfoBL;
        }

        public async Task<IActionResult> Index()
        {
            var accountInfo = await _accountInfoBL.GetAccountInfo();
            if (!accountInfo.Status) { }


            return View(accountInfo.Data);
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