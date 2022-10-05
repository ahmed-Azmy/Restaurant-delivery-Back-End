using Restaurant.BLL.Specifications.RestaurantSpecifications;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Specifications.MealSecifications
{
    public class MealsWithRestaurantSpecification : BaseSpecification<Meal>
    {
        public MealsWithRestaurantSpecification(RestaurantSpecParams restaurantSpecParams) :
            base(M =>
                 (string.IsNullOrEmpty(restaurantSpecParams.Search) || M.Name.ToLower().Contains(restaurantSpecParams.Search)) &&
                 (!restaurantSpecParams.RestaurantId.HasValue || restaurantSpecParams.RestaurantId == M.RestaurantId)
                )
        {
            AddInclude(M => M.Restaurant);
            ApplyPaging(restaurantSpecParams.PageSize * (restaurantSpecParams.PageIndex - 1), restaurantSpecParams.PageSize);
            ApplyOrderBy(M => M.Name);
        }
    }
}
