using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered;
using Refacto.DotNet.DAL.Database.Context;
using Refacto.DotNet.DAL.Entities;

namespace Refacto.DotNet.Triggers
{
    public class OnProductSavedTrigger : IBeforeSaveTrigger<Product>
    {
        private readonly AppDbContext _context;

        public OnProductSavedTrigger(AppDbContext context)
        {
            _context = context;
        }

        public async Task BeforeSave(ITriggerContext<Product> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType != ChangeType.Modified)
                return;

            var oldProduct = context.UnmodifiedEntity!;
            var newProduct = context.Entity;

            if (oldProduct.Available != newProduct.Available)
            {
                newProduct.Vendu += Math.Abs(oldProduct.Available - newProduct.Available);
                await _context.SaveChangesAsync();
            }
        }
    }
}
