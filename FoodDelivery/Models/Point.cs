using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public class Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public List<Dish> Dishes { get; set; }

        public Point()
        {
            Dishes = new List<Dish>();
        }
    }
}