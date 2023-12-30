using Refacto.DotNet.DAL.Database.Context;
using Refacto.DotNet.Interfaces;
using Refacto.DotNet.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refacto.DotNet.BLL.Strategies.Product
{
    public class ExpirableProductHandler : IProductHandler
    {
        public void HandleProduct(DAL.Entities.Product p, AppDbContext _ctx, IProductService _productService)
        {
            if (p.Available > 0 && p.ExpiryDate > DateTime.Now.Date)
            {
                p.Available -= 1;
                _ = _ctx.SaveChanges();
            }
            else
            {
                _productService.HandleExpiredProduct(p);
            }
        }
    }
}
