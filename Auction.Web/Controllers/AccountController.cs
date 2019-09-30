using Microsoft.AspNetCore.Mvc;

namespace Auction.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}