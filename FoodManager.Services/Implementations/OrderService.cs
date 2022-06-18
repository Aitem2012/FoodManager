using FoodManager.Application.DTO.Orders;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Services.Abstracts;

namespace FoodManager.Services.Implementations
{
    public class OrderService : IOrderService
    {
        public int OrderCount { get;set; }
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<BaseResponse<bool>> AddOrderAsync(CreateOrderDto order)
        {
            return await _orderRepository.AddOrderAsync(order);
        }

        public async Task<BaseResponse<bool>> DeleteOrderAsync(Guid orderId)
        {
            return await _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<BaseResponse<GetOrderResponseObjectDto>> GetOrderByIdAsync(Guid orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }
    }
}
