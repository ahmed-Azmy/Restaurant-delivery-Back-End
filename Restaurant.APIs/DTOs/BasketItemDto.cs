using System.ComponentModel.DataAnnotations;

namespace Restaurant.APIs.DTOs
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string MealName { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must be Greater Than zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity Must be At Least One Item")]
        public int Quantity { get; set; }
        [Required]
        public string PictureUrl { get; set; }
    }
}
