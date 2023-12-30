using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Refacto.DotNet.DTO.Product;
using Refacto.DotNet.Interfaces.Services;

namespace Refacto.DotNet.Controllers.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{orderId}/processOrder")]
        [ProducesResponseType(200)]
        public ActionResult<ProcessOrderResponse> ProcessOrder(long orderId)
        {
            var order = _orderService.ProcessOrder(orderId);

            if (order == null)
                return NotFound($"Could not find order N° {orderId}");

            return Ok(new ProcessOrderResponse(order.Id));
        }
    }
}
