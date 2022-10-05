using AutoMapper;
using Microsoft.Extensions.Configuration;
using Restaurant.APIs.DTOs;
using Restaurant.DAL.Entities;

namespace Restaurant.APIs.Helpers
{
    public class MealUrlResolver : IValueResolver<Meal, MealDto, string>
    {
        private readonly IConfiguration configuration;
        public MealUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(Meal source, MealDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(destMember))
                return $"{configuration["ApiImgUrl"]}{source.PictureUrl}";
            return null;
        }
    }
}
