using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public List<Order> Orders { get; set; }

        public Basket()
        {
            
            Orders = new List<Order>();
        }
    }
}