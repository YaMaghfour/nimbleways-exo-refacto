
using Refacto.DotNet.DAL.Entities;

namespace Refacto.DotNet.Interfaces.Services
{
    public interface IProductService
    {
        void NotifyDelay(int leadTime, Product p);
        void HandleSeasonalProduct(Product p);
        void HandleExpiredProduct(Product p);
        void HandleFlashSaleProduct(Product p);
    }
}
