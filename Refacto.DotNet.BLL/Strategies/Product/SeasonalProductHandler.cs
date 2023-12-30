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
    public class SeasonalProductHandler : IProductHandler
    {
        public void HandleProduct(DAL.Entities.Product p, AppDbContext _ctx, IProductService _productService)
        {
            if (DateTime.Now.Date > p.StartDate && DateTime.Now.Date < p.EndDate && p.Available > 0)
            {
                p.Available -= 1;
                _ = _ctx.SaveChanges();
            }
            else
            {
                _productService.HandleSeasonalProduct(p);
            }
        }
    }
}
