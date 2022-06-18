using FoodManager.Application.DTO.Orders;
using FoodManager.Common.Response;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public int OrderCount { get; set; }
        public Task<BaseResponse<bool>> AddOrderAsync(CreateOrderDto order);
        public Task<BaseResponse<bool>> DeleteOrderAsync(Guid orderId);
        public Task<BaseResponse<GetOrderResponseObjectDto>> GetOrderByIdAsync(Guid orderId);
        public Task<BaseResponse<GetOrderResponseObjectDto>> GetOrderByTrackingNumberAsync(string trackingNumber);
    }
}
