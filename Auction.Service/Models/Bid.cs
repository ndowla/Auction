using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Service.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public double BidAmount { get; set; }

        public int UserId { get; set; }

        public DateTime BidDateTime { get; set; }
    }
}
