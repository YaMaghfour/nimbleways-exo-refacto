using Microsoft.EntityFrameworkCore;
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
    public class NormalProductHandler : IProductHandler
    {
        public void HandleProduct(DAL.Entities.Product p, AppDbContext _ctx, IProductService _productService)
        {
            if (p.Available > 0)
            {
                p.Available -= 1;
                _ctx.Entry(p).State = EntityState.Modified;
                _ = _ctx.SaveChanges();

            }
            else
            {
                int leadTime = p.LeadTime;
                if (leadTime > 0)
                {
                    _productService.NotifyDelay(leadTime, p);
                }
            }
        }
    }
}
