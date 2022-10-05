using AutoMapper;
using Microsoft.Extensions.Configuration;
using Restaurant.APIs.DTOs;
using Restaurant.DAL.Entities;

namespace Restaurant.APIs.Helpers
{
    public class PictureUrlResolver : IValueResolver<Resturant, RestaurantDto, string>
    {
        private readonly IConfiguration configuration;
        public PictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Resturant source, RestaurantDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(destMember))
                return $"{configuration["ApiImgUrl"]}{source.PictureUrl}";
            return null;
        }
    }
}
