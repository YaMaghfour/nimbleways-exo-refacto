using Refacto.DotNet.DAL.Database.Context;
using Refacto.DotNet.DAL.Entities;
using Refacto.DotNet.Interfaces;
using Refacto.DotNet.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refacto.DotNet.BLL.Strategies.Product
{
    public class FlashSaleProductHandler : IProductHandler
    {
        public void HandleProduct(DAL.Entities.Product product, AppDbContext _ctx, IProductService _productService)
        {
            if (IsAvailableFlashSaleProduct(product))
            {
                product.Available -= 1;
                _ = _ctx.SaveChanges();
            }
            else
            {
                _productService.HandleFlashSaleProduct(product);
            }
        }

        private bool IsAvailableFlashSaleProduct(DAL.Entities.Product Product)
        {
            return Product.Available > 0
                && DateTime.Now.Date >= Product.StartDate && DateTime.Now.Date <= Product.EndDate
                && Product.Vendu < Product.MaxSellQuantity;
        }

    }
}
