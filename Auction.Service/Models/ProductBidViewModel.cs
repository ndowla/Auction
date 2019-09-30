using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Service.Models
{
    public class ProductBidViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double StartPrice { get; set; }

        public double CurrentPrice { get; set; }

        public double BidAmount { get; set; }

        public string SellerName { get; set; }

        public int SellerId { get; set; }

        public DateTime AuctionEndDate { get; set; }
    }
}
