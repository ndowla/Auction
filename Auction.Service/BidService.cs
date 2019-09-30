using Auction.Service.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Service
{
    public class BidService : IBidService
    {
        private readonly IHttpContextAccessor _context;
        private List<Bid> Bids => _context.HttpContext.Session.GetObject<List<Bid>>("AuctionBids");
        public BidService(IHttpContextAccessor context)
        {
            _context = context;
        }

        /// <summary>
        /// Insert seed data to session only once
        /// </summary>
        public void SetBids()
        {
            if (_context.HttpContext.Session.GetString("AuctionBids") == null)
            {
                var bids = new List<Bid>();
                bids.Add(new Bid { ProductId = 1, UserId = 3, BidAmount = 38, BidDateTime = DateTime.Now });
                bids.Add(new Bid { ProductId = 3, UserId = 2, BidAmount = 110, BidDateTime = DateTime.Now });
                _context.HttpContext.Session.SetObject("AuctionBids", bids);
            }
        }

        /// <summary>
        /// Get all bids for products 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public List<Bid> GetBids(List<Product> products)
        {
            return Bids.Where(b => products.Any(p => p.Id == b.ProductId)).ToList();
        }

        /// <summary>
        /// Add to bid repo for single bid
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <param name="bidAmount"></param>
        public void PlaceBid(int productId, int userId, double bidAmount)
        {
            var currentBids = Bids;
            currentBids.Add(new Bid { ProductId = productId, UserId = userId, BidAmount = bidAmount, BidDateTime = DateTime.Now });
            _context.HttpContext.Session.SetObject("AuctionBids", currentBids);
        }

        
    }
}
