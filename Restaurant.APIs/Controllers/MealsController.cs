using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.APIs.DTOs;
using Restaurant.APIs.Helpers;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Specifications.MealSecifications;
using Restaurant.BLL.Specifications.RestaurantSpecifications;
using Restaurant.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.APIs.Controllers
{
    public class MealsController : BaseApiController
    {
        private readonly IGenericRepository<Meal> mealRepository;
        private readonly IMapper mapper;

        public MealsController(IGenericRepository<Meal> MealRepository, IMapper mapper)
        {
            mealRepository = MealRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Pagination<MealDto>>>> GetMeals([FromQuery] RestaurantSpecParams restaurantSpecParams)
        {
            var Spec = new MealsWithRestaurantSpecification(restaurantSpecParams);
            var CountSpec = new MealsWithFiltersForCountSpecification(restaurantSpecParams);
            var TotalItems = await mealRepository.GetCountAsync(CountSpec);
            var Meals = await mealRepository.GetAllWithSpecAsync(Spec);

            var MealsDto = mapper.Map<IReadOnlyList<Meal>, IReadOnlyList<MealDto>>(Meals);
            if (MealsDto == null) return NotFound();

            return Ok(new Pagination<MealDto>(restaurantSpecParams.PageIndex, restaurantSpecParams.PageSize, TotalItems, MealsDto));
        }
    }
}
