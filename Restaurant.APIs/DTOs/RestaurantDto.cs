using Restaurant.DAL.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Restaurant.APIs.DTOs
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        [JsonIgnore] 
        public ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
    }
}
