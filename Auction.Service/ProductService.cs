using Auction.Service.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpContextAccessor _context;
        private IBidService _bidService;
        private List<Product> Products => _context.HttpContext.Session.GetObject<List<Product>>("AuctionProducts");

        public ProductService(IHttpContextAccessor context, IBidService bidService)
        {
            _context = context;
            _bidService = bidService;
        }

        /// <summary>
        /// Insert seed data to session only once
        /// </summary>
        public void SetProducts()
        {
            if (_context.HttpContext.Session.GetString("AuctionProducts") == null)
            {
                var products = new List<Product>();
                products.Add(new Product { Id = 1, Name = "Men's Shoes", Description = "Men's Grey Shoes, Size 12", SellerUserId = 1, AuctionStartTime = DateTime.Now.AddDays(-1), AuctionEndTime = DateTime.Now.AddMinutes(1), StartPrice = 35 });
                products.Add(new Product { Id = 2, Name = "Small Handbag", Description = "Women's Purple Handbag, Leather", SellerUserId = 2, AuctionStartTime = DateTime.Now.AddDays(-3), AuctionEndTime = DateTime.Now.AddMinutes(30), StartPrice = 50 });
                products.Add(new Product { Id = 3, Name = "Large Handbag", Description = "Women's Large Bag, Black", SellerUserId = 1, AuctionStartTime = DateTime.Now.AddDays(-1), AuctionEndTime = DateTime.Now.AddMinutes(5), StartPrice = 100 });
                products.Add(new Product { Id = 4, Name = "Table Tennis Paddle Set", Description = "Full set of balls and paddles, multicolored", SellerUserId = 3, AuctionStartTime = DateTime.Now.AddDays(-1), AuctionEndTime = DateTime.Now.AddDays(1), StartPrice = 12.50 });
                _context.HttpContext.Session.SetObject("AuctionProducts", products);
            }
        }

        /// <summary>
        /// Get list of products that user is able to bid on
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ProductBidViewModel> GetCurrentAuctionProducts(int userId)
        {
            var currentDateTime = DateTime.Now;
            var products = Products.Where(p => p.AuctionEndTime > currentDateTime
                                    && p.AuctionStartTime <= currentDateTime
                                    && p.SellerUserId != userId).ToList();

            var bids = _bidService.GetBids(products);

            var productBidsViewModel = products.Select(p => new ProductBidViewModel
            {
                ProductId = p.Id,
                Name = p.Name,
                AuctionEndDate = p.AuctionEndTime,
                Description = p.Description,
                StartPrice = p.StartPrice,
                SellerId = p.SellerUserId,
                SellerName = "Jane" //todo create service to get username by Id
            }).ToList();

            for (int i = 0; i < productBidsViewModel.Count(); i++)
            {
                var currentBid = bids.Where(b => b.ProductId == productBidsViewModel[i].ProductId).OrderByDescending(b => b.BidDateTime).FirstOrDefault();
                productBidsViewModel[i].CurrentPrice = currentBid != null ? currentBid.BidAmount : productBidsViewModel[i].StartPrice;
            }

            return productBidsViewModel;
        }

        /// <summary>
        /// Get product and bid data for single product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductBidViewModel GetCurrentAuctionProductByProductId(int productId)
        {
            var product = Products.SingleOrDefault(p => p.Id == productId);

            if (product == null)
                throw new Exception($"Product Id does not exist:{productId}");

            var bids = _bidService.GetBids(new List<Product> { product });

            var productBidViewModel = new ProductBidViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                AuctionEndDate = product.AuctionEndTime,
                Description = product.Description,
                StartPrice = product.StartPrice,
                SellerId = product.SellerUserId,
                SellerName = "Jane" //todo create user service to get username by Id
            };

            var currentBid = bids.Where(b => b.ProductId == product.Id).OrderByDescending(b => b.BidDateTime).FirstOrDefault();
            productBidViewModel.CurrentPrice = currentBid != null ? currentBid.BidAmount : productBidViewModel.StartPrice;

            return productBidViewModel;
        }
    }
}
