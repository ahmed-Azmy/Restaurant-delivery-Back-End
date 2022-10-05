using Restaurant.BLL.Specifications.RestaurantSpecifications;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Specifications.MealSecifications
{
    public class MealsWithFiltersForCountSpecification : BaseSpecification<Meal>
    {
        public MealsWithFiltersForCountSpecification(RestaurantSpecParams restaurantSpecParams) :
            base(M =>
                 (string.IsNullOrEmpty(restaurantSpecParams.Search) || M.Name.ToLower().Contains(restaurantSpecParams.Search)) &&
                 (!restaurantSpecParams.RestaurantId.HasValue || restaurantSpecParams.RestaurantId == M.RestaurantId)
                )
        {

        }
    }
}
