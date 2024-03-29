﻿using AutoMapper;
using FoodManager.Application.DTO.Orders;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Extensions;
using FoodManager.Common.Response;
using FoodManager.Domain.Enums;
using FoodManager.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace FoodManager.Persistence.Implementations.Orders
{
    public class OrderRepository : IOrderRepository
    {
        public int OrderCount { get; set; }

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public OrderRepository(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<BaseResponse<bool>> AddOrderAsync(CreateOrderDto order)
        {
            var completedOrder = _mapper.Map<Order>(order);
            completedOrder = await CalculateTotal(completedOrder);
            completedOrder.ConfirmationStatus = ConfirmationStatus.Pending;
            completedOrder.DeliveryStatus = DeliveryStatus.Pending;
            completedOrder.PaymentStatus = PaymentStatus.Pending;
            completedOrder.PaymentMethod = order.PaymentMethod.ToString();
            _context.Orders.Add(completedOrder);
            return new BaseResponse<bool>().CreateResponse("", true, await _context.SaveChangesAsync(new CancellationToken()) > 0);
        }

        public async Task<BaseResponse<bool>> DeleteOrderAsync(Guid orderId)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x => x.Id.Equals(orderId));
            if (order.IsNullOrEmpty())
            {
                return new BaseResponse<bool>().CreateResponse($"Order could not be deleted", false, false);
            }
            _context.Orders.Remove(order);
            return new BaseResponse<bool>().CreateResponse("", true, await _context.SaveChangesAsync(new CancellationToken()) > 0);
        }


        public async Task<BaseResponse<Order>> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Menu).FirstOrDefaultAsync(x => x.Id.Equals(orderId));
            return new BaseResponse<Order>().CreateResponse("", true, order);
        }

        public async Task<BaseResponse<Order>> GetOrderByTrackingNumberAsync(string trackingNumber)
        {
            var order = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Menu).FirstOrDefaultAsync(x => x.TrackingNumber.Equals(trackingNumber));
            return new BaseResponse<Order>().CreateResponse("", true, order);
        }

        public async Task<BaseResponse<IEnumerable<Order>>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Menu).Where(x => x.AppUserId.Equals(userId)).ToListAsync();
            return new BaseResponse<IEnumerable<Order>>().CreateResponse("", true, orders);
        }
        private async Task<Order> CalculateTotal(Order order)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var items = order.OrderItems.ToDictionary(x => x.MenuId, x => x.Quantity);
            var menus = await _context.Menus.Where(x => items.Keys.Contains(x.Id))
                                            .Select(x => new { SellingPrice = x.UnitPrice, Id = x.Id })
                                            .ToListAsync();
            foreach (var item in menus)
            {
                order.PaymentAmount += item.SellingPrice * items[item.Id];
            }
            //Todo: Calculate delivery cost
            order.User = await _context.Users.FindAsync(order.AppUserId);
            order.TrackingNumber = string.Format("{0:yyMMddhhmmss}", DateTime.Now) + rand.Next(1000, 9999).ToString();
            return order;
        }

        public async Task<BaseResponse<IEnumerable<Order>>> GetOrdersForAdminAsync()
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Menu).ToListAsync();
            return new BaseResponse<IEnumerable<Order>>().CreateResponse($"Retrieved: {orders.Count} successfully",
                true, orders);
        }
    }
}
