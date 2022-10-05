using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Specifications.OrderSpecifications;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IBasketRepository basketRepository,
                           IUnitOfWork unitOfWork
                           )
        {
            this.basketRepository = basketRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId, string shipToAddress)
        {
            // 1. Get Basket From Basket Repository
            var basket = await basketRepository.GetCustomerBasket(basketId);
            // 2. Get Selected Item at Basket From Products Repo
            var orderItems = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var meal = await unitOfWork.Repository<Meal>().GetAsync(item.Id);
                var OrderItem = new OrderItem(meal.Id, meal.Name, meal.PictureUrl, meal.Price, item.Quantity);
                orderItems.Add(OrderItem);
            }
            //4. Calculate total
            var total = orderItems.Sum(item => item.Price * item.Quantity);
            //5. Create Order
            var order = new Order(buyerEmail, shipToAddress, orderItems, total);
            await unitOfWork.Repository<Order>().Add(order);
            //6. Save To Database
            int result = await unitOfWork.Complete();
            if (result <= 0) return null;

            return order;

        }

        public Task<Order> GetOrderByIdForUser(int orderId, string buyerEmail)
        {
            var spec = new OrderWithHisItemsSpecification(orderId, buyerEmail);

            var order = unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);

            return order;
        }
        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithHisItemsSpecification(buyerEmail);
            var orders = await unitOfWork.Repository<Order>().GetAllWithSpecAsync(spec);

            return orders;
        }
    }
}
