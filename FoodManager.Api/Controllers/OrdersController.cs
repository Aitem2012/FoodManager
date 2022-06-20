using FoodManager.Application.DTO.OrderItems;
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
        /// Create an order
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(AddOrder)), ProducesResponseType(typeof(BaseResponse<bool>), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> AddOrder([FromBody]CreateOrderDto order)
        {
            return Ok(await _orderService.AddOrderAsync(order));
        }

        /// <summary>
        /// Get an order by Id
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet("/{orderId}", Name = nameof(GetOrderById)), ProducesResponseType(typeof(BaseResponse<GetOrderResponseObjectDto>), StatusCodes.Status200OK), ProducesDefaultResponseType]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid orderId)
        {
            return Ok(await _orderService.GetOrderByIdAsync(orderId));
        }
        
        /// <summary>
        /// Get an order by trackingNumber
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet("{trackingNumber}", Name = nameof(GetOrderByTrackingNumber)), ProducesResponseType(typeof(BaseResponse<GetOrderResponseObjectDto>), StatusCodes.Status200OK), ProducesDefaultResponseType]
        public async Task<IActionResult> GetOrderByTrackingNumber([FromRoute] string trackingNumber)
        {
            return Ok(await _orderService.GetOrderByTrackingNumberAsync(trackingNumber));
        }
        
        /// <summary>
        /// Get an order by trackingNumber
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet("/get-orders-for-user/{userId}", Name = nameof(GetOrdersByUserId)), ProducesResponseType(typeof(BaseResponse<IEnumerable<GetOrderResponseObjectDto>>), StatusCodes.Status200OK), ProducesDefaultResponseType]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] string userId)
        {
            return Ok(await _orderService.GetOrdersByUserIdAsync(userId));
        }

        /// <summary>
        /// Get orders for admin
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet("/get-orders-for-admin", Name = nameof(GetOrdersByAdmin)), ProducesResponseType(typeof(BaseResponse<IEnumerable<GetOrderResponseObjectDto>>), StatusCodes.Status200OK), ProducesDefaultResponseType]
        public async Task<IActionResult> GetOrdersByAdmin()
        {
            return Ok(await _orderService.GetOrdersForAdminAsync());
        }

        /// <summary>
        /// Get an order detail by orderid
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet("/get-orders-details", Name = nameof(GetOrderDetail)), ProducesResponseType(typeof(BaseResponse<IEnumerable<GetOrderItemResponseObjectDto>>), StatusCodes.Status200OK), ProducesDefaultResponseType]
        public async Task<IActionResult> GetOrderDetail(Guid orderId)
        {
            return Ok(await _orderService.GetOrderDetailsAsync(orderId));
        }
    }
}
