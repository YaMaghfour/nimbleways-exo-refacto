using Refacto.DotNet.Controllers.Entities;

namespace Refacto.DotNet.Controllers.Services
{
    public interface IProductService
    {
        void NotifyDelay(int leadTime, Product p);
        void HandleSeasonalProduct(Product p);
        void HandleExpiredProduct(Product p);
    }
}
