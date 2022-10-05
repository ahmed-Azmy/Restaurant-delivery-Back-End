using AutoMapper;
using Restaurant.APIs.DTOs;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Entities.Basket;
using Restaurant.DAL.Entities.Order;

namespace Restaurant.APIs.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Resturant, RestaurantDto>()
                .ForMember(R => R.City, O => O.MapFrom(R => R.City.Name))
                .ForMember(R => R.PictureUrl, O => O.MapFrom<PictureUrlResolver>());
            
            CreateMap<Meal, MealDto>()
                .ForMember(M => M.Restaurant, O => O.MapFrom(M => M.Restaurant.Name))
                .ForMember(M => M.PictureUrl, O => O.MapFrom<MealUrlResolver>());

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<Order, OrderToReturnDto>();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, O => O.MapFrom(S => S.ProductId))
                .ForMember(d => d.ProductName, O => O.MapFrom(S => S.ProductName))
                .ForMember(d => d.PictureUrl, O => O.MapFrom(S => S.PictureUrl))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<OrderItemUrlResolver>());
        }
    }
}
