using Refacto.DotNet.BLL.Services;
using Refacto.DotNet.BLL.Strategies.Product;
using Refacto.DotNet.DAL.Database.Context;
using Refacto.DotNet.DAL.Entities;
using Refacto.DotNet.Interfaces;
using Refacto.DotNet.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refacto.DotNet.BLL.Strategies
{
    public class ProductProcessor
    {
        private readonly Dictionary<string, IProductHandler> _handlers;

        public ProductProcessor()
        {
            _handlers = new Dictionary<string, IProductHandler>
            {
                { Constants.ProductType.NORMAL, new NormalProductHandler() },
                { Constants.ProductType.SEASONAL, new SeasonalProductHandler() },
                { Constants.ProductType.EXPIRABLE, new ExpirableProductHandler() },
                { Constants.ProductType.FLASHSALE, new FlashSaleProductHandler() },
            };
        }

        public void ProcessProduct(DAL.Entities.Product product, AppDbContext _ctx, IProductService productService)
        {
            if (string.IsNullOrEmpty(product.Type))
                throw new Exception("Product type null");

            if (_handlers.TryGetValue(product.Type, out var handler))
            {
                handler.HandleProduct(product, _ctx, productService);
            }
        }

    }
}
