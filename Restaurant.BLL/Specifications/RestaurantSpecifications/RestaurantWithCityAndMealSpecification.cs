using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Specifications.RestaurantSpecifications
{
    public class RestaurantWithCityAndMealSpecification : BaseSpecification<Resturant>
    {
        public RestaurantWithCityAndMealSpecification(RestaurantSpecParams restaurantSpecParams) :
            base(R =>
                 (string.IsNullOrEmpty(restaurantSpecParams.Search) || R.Name.ToLower().Contains(restaurantSpecParams.Search)) &&
                 (!restaurantSpecParams.CityId.HasValue || restaurantSpecParams.CityId == R.CityId)
                )
        {
            AddInclude(R => R.City);
            AddInclude(R => R.Meals);
            ApplyPaging(restaurantSpecParams.PageSize * (restaurantSpecParams.PageIndex - 1), restaurantSpecParams.PageSize);
            ApplyOrderBy(R => R.Name);
        }
    }
}
