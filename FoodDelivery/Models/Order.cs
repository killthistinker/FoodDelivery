namespace FoodDelivery.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public int DishId { get; set; }
    }
}