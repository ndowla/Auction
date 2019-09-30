using Auction.Service;
using Auction.Web.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auction.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpContextAccessor _context;
        IProductService _productService;
        IBidService _bidService;

        private int currentUserId => _context.HttpContext.Session.GetInt32("AuctionCurrentUserId").Value;

        public ProductController(IProductService productService, IBidService bidService, IHttpContextAccessor context)
        {
            _productService = productService;
            _bidService = bidService;
            _context = context;
        }

        [Route("Product/{id:int}")]
        public IActionResult Product(int id)
        {
            var model = _productService.GetCurrentAuctionProductByProductId(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Bid(ProductViewModel model)
        {
            if(model.AuctionEndDate <= DateTime.Now)
                return RedirectToAction("Product", new { id = model.ProductId });

            _bidService.PlaceBid(model.ProductId, currentUserId, model.BidAmount);
            return RedirectToAction("DashBoard", "Account");
        }
    }
}