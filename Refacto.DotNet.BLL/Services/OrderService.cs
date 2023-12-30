using Microsoft.EntityFrameworkCore;
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

            foreach (Product p in products)
            {
                if (p.Type == "NORMAL")
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
                else if (p.Type == "SEASONAL")
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
                else if (p.Type == "EXPIRABLE")
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

            return order;
        }
    }
}
