using Auction.Service.Models;
using System.Collections.Generic;

namespace Auction.Service
{
    public interface IProductService
    {
        void SetProducts();

        List<ProductBidViewModel> GetCurrentAuctionProducts(int userId);

        ProductBidViewModel GetCurrentAuctionProductByProductId(int productId);
    }
}
