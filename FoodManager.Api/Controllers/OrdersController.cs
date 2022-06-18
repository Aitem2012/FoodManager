using FoodManager.Application.DTO.Orders;
using FoodManager.Common.Response;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.Api.Controllers
{
    /// <summary>
    /// This handles all requests for menus
    /// </summary>
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _orderService;
        public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        /// <summary>
        /// Get all menus
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(AddOrder)), ProducesResponseType(typeof(BaseResponse<bool>), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> AddOrder([FromBody]CreateOrderDto order)
        {
            return Ok(await _orderService.AddOrderAsync(order));
        }
    }
}
