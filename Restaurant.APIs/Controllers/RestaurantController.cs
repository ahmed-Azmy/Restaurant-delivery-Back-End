using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.APIs.DTOs;
using Restaurant.APIs.Helpers;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Specifications.RestaurantSpecifications;
using Restaurant.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.APIs.Controllers
{
    public class RestaurantController : BaseApiController
    {
        private readonly IGenericRepository<Resturant> restaurantRepository;
        private readonly IGenericRepository<City> cityRepository;
        private readonly IMapper mapper;

        public RestaurantController(IGenericRepository<Resturant> RestaurantRepository,
                                    IGenericRepository<City> CityRepository,
                                    IMapper mapper)
        {
            restaurantRepository = RestaurantRepository;
            cityRepository = CityRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Pagination<RestaurantDto>>>> GetRestaurants([FromQuery]RestaurantSpecParams restaurantSpecParams)
        {
            var Spec = new RestaurantWithCityAndMealSpecification(restaurantSpecParams);
            var CountSpec = new RestaurantWithFiltersForCountSpecification(restaurantSpecParams);
            var TotalItems = await restaurantRepository.GetCountAsync(CountSpec);
            var Restaurants = await restaurantRepository.GetAllWithSpecAsync(Spec);

            var RestaurantsDto = mapper.Map<IReadOnlyList<Resturant>, IReadOnlyList<RestaurantDto>>(Restaurants);
            if (RestaurantsDto == null) return NotFound();

            return Ok(new Pagination<RestaurantDto>(restaurantSpecParams.PageIndex, restaurantSpecParams.PageSize, TotalItems, RestaurantsDto));
        }
        [HttpGet("cities")]
        public async Task<ActionResult<IReadOnlyList<City>>> GetCities()
        {
            var Cities = await cityRepository.GetAllAsync();
            if (Cities == null) return NotFound();
            return Ok(Cities);
        }
    }
}
