using Business.Abstract;
using Entities.Dtos.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpPost]
        public async Task<IActionResult> Add(OrderInsertDto orderInsertDto)
            => Ok(await _orderService.Add(orderInsertDto));



        [HttpPut]
        public async Task<IActionResult> Pay(int orderId, OrderPaymentDto orderPaymentDto)
            => Ok(await _orderService.Pay(orderId, orderPaymentDto));


    }
}
