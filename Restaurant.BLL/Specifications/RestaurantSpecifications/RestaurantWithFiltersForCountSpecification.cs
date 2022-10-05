using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Specifications.RestaurantSpecifications
{
    public class RestaurantWithFiltersForCountSpecification : BaseSpecification<Resturant>
    {
        public RestaurantWithFiltersForCountSpecification(RestaurantSpecParams restaurantSpecParams) :
            base(R =>
                 (string.IsNullOrEmpty(restaurantSpecParams.Search) || R.Name.ToLower().Contains(restaurantSpecParams.Search)) &&
                 (!restaurantSpecParams.CityId.HasValue || restaurantSpecParams.CityId == R.CityId)
                )
        {

        }
    }
}
