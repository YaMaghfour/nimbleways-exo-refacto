using Refacto.DotNet.DAL.Database.Context;
using Refacto.DotNet.DAL.Entities;
using Refacto.DotNet.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refacto.DotNet.Interfaces
{
    public interface IProductHandler
    {
        void HandleProduct(Product product, AppDbContext _ctx, IProductService _productService);
    }
}
