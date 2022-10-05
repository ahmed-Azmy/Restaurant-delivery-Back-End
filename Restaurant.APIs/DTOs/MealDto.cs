namespace Restaurant.APIs.DTOs
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
