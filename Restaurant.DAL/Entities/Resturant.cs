using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities
{
    public class Resturant : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
    }
}
