using Microsoft.EntityFrameworkCore;
using Refacto.DotNet.BLL.Strategies;
using Refacto.DotNet.DAL.Database.Context;
using Refacto.DotNet.DAL.Entities;
using Refacto.DotNet.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refacto.DotNet.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _ctx;
        private readonly IProductService _productService;

        public OrderService(AppDbContext ctx, IProductService productService)
        {
            _ctx = ctx;
            _productService = productService;
        }

        public Order? ProcessOrder(long OrderId)
        {
            Order? order = _ctx.Orders
                .Include(o => o.Items)
                .SingleOrDefault(o => o.Id == OrderId);

            Console.WriteLine(order);

            if (order == null)
                return null;

            List<long> ids = new() { OrderId };
            ICollection<Product>? products = order.Items;

            ProductProcessor productProcessor = new();

            foreach (Product p in products)
                productProcessor.ProcessProduct(p, _ctx, _productService);

            return order;
        }
    }
}
