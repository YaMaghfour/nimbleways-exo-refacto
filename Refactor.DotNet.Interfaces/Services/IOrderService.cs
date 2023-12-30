using Refacto.DotNet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refacto.DotNet.Interfaces.Services
{
    public interface IOrderService
    {
        Order? ProcessOrder(long OrderId);
    }
}
