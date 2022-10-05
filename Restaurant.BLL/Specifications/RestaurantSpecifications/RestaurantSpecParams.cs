using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Specifications.RestaurantSpecifications
{
    public class RestaurantSpecParams
    {
        private const int PageMaxSize = 50;
        public int PageIndex { get; set; } = 1;

        private int pageSize = 1;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > PageMaxSize ? PageMaxSize : value; }
        }
        public string Sort { get; set; }
        public int? CityId { get; set; }
        public int? RestaurantId { get; set; }

        private string search;
        public string Search
        {
            get { return search; }
            set { search = value.ToLower(); }
        }
    }
}
