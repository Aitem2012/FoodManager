using FoodManager.Application.DTO.OrderItems;
using FoodManager.Application.DTO.Orders;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface IOrderService
    {
        public int OrderCount { get; set; }
        public Task<BaseResponse<bool>> AddOrderAsync(CreateOrderDto order);
        public Task<BaseResponse<bool>> DeleteOrderAsync(Guid orderId);
        public Task<BaseResponse<GetOrderResponseObjectDto>> GetOrderByIdAsync(Guid orderId);
        public Task<BaseResponse<GetOrderResponseObjectDto>> GetOrderByTrackingNumberAsync(string trackingNumber);
        public Task<BaseResponse<IEnumerable<GetOrderResponseObjectDto>>> GetOrdersByUserIdAsync(string userId);
        public Task<BaseResponse<IEnumerable<GetOrderResponseObjectDto>>> GetOrdersForAdminAsync();
        public Task<BaseResponse<IEnumerable<GetOrderItemResponseObjectDto>>> GetOrderDetailsAsync(Guid orderId);
    }
}
