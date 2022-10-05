using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public Resturant Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
