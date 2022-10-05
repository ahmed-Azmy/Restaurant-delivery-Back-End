using AutoMapper;
using Microsoft.Extensions.Configuration;
using Restaurant.APIs.DTOs;
using Restaurant.DAL.Entities.Order;

namespace Restaurant.APIs.Helpers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration configuration;
        public OrderItemUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["ApiImgUrl"]}{source.PictureUrl}";
            return null;
        }
    }
}
