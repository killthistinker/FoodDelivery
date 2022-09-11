
using System.Text.Json.Serialization;

namespace FoodDelivery.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int PointId { get; set; }
        [JsonIgnore]
        public Point Point { get; set; }
    }
}