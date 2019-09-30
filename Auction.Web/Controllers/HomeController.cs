using Auction.Models;
using Auction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _context;
        IProductService _productService;
        IBidService _bidService;

        private int currentUserId => _context.HttpContext.Session.GetInt32("AuctionCurrentUserId").Value;
        public HomeController(IProductService productService, IBidService bidService, IHttpContextAccessor context)
        {
            _productService = productService;
            _bidService = bidService;
            _context = context;
        }

        /// <summary>
        /// Insert test data if the session key is null for users, products, bids
        /// Hard code user Id for session
        /// Should be moved to application startup if possible
        /// </summary>
        private void InsertSeedData()
        {
            if (_context.HttpContext.Session.GetInt32("AuctionCurrentUserId") == null)
                _context.HttpContext.Session.SetInt32("AuctionCurrentUserId", 2);

            _productService.SetProducts();
            _bidService.SetBids();
        }

        public IActionResult Index()
        {
            InsertSeedData();
            var model = _productService.GetCurrentAuctionProducts(currentUserId); 
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
