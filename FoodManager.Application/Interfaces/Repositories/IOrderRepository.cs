using FoodManager.Application.DTO.Orders;
using FoodManager.Common.Response;
using FoodManager.Domain.Orders;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public int OrderCount { get; set; }
        public Task<BaseResponse<bool>> AddOrderAsync(CreateOrderDto order);
        public Task<BaseResponse<bool>> DeleteOrderAsync(Guid orderId);
        public Task<BaseResponse<Order>> GetOrderByIdAsync(Guid orderId);
        public Task<BaseResponse<IEnumerable<Order>>> GetOrdersByUserIdAsync(string userId);
        public Task<BaseResponse<Order>> GetOrderByTrackingNumberAsync(string trackingNumber);
        public Task<BaseResponse<IEnumerable<Order>>> GetOrdersForAdminAsync();
    }
}
