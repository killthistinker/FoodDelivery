namespace FoodDelivery.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int DishCount { get; set; }
    }
}