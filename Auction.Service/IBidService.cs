using Auction.Service.Models;
using System.Collections.Generic;

namespace Auction.Service
{
    public interface IBidService
    {
        void SetBids();
        List<Bid> GetBids(List<Product> products);
        void PlaceBid(int productId, int userId, double bidAmount);
    }
}