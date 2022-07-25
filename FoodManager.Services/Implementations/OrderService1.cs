using AutoMapper;
using FoodManager.Application.DTO.OrderItems;
using FoodManager.Application.DTO.Orders;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Domain.Orders;
using FoodManager.Services.Abstracts;

namespace FoodManager.Services.Implementations
{
    public class OrderService1 : IOrderService
    {
        public int OrderCount { get;set; }
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService1(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            return new BaseResponse<GetOrderResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetOrderResponseObjectDto>(order.Data));
        }

        public async Task<BaseResponse<GetOrderResponseObjectDto>> GetOrderByTrackingNumberAsync(string trackingNumber)
        {
            var order = await _orderRepository.GetOrderByTrackingNumberAsync(trackingNumber);
            return new BaseResponse<GetOrderResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetOrderResponseObjectDto>(order.Data));
        }

        public async Task<BaseResponse<IEnumerable<GetOrderResponseObjectDto>>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return new BaseResponse<IEnumerable<GetOrderResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetOrderResponseObjectDto>>(orders.Data));
        }

        public async Task<BaseResponse<IEnumerable<GetOrderResponseObjectDto>>> GetOrdersForAdminAsync()
        {
            var orders = await _orderRepository.GetOrdersForAdminAsync();
            return new BaseResponse<IEnumerable<GetOrderResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetOrderResponseObjectDto>>(orders.Data));
        }

        public async Task<BaseResponse<IEnumerable<GetOrderItemResponseObjectDto>>> GetOrderDetailsAsync(Guid orderId)
        {
            var orderDetails = GetOrderById(orderId).Result.Data.OrderItems;
            return new BaseResponse<IEnumerable<GetOrderItemResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetOrderItemResponseObjectDto>>(orderDetails));
        }

        private async Task<BaseResponse<Order>> GetOrderById(Guid Id)
        {
            return await _orderRepository.GetOrderByIdAsync(Id);
        }
    }
}
