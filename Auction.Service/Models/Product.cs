using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Service.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SellerUserId { get; set; }
        public DateTime AuctionStartTime { get; set; }
        public DateTime AuctionEndTime { get; set; }
        public double StartPrice { get; set; }
    }
}
