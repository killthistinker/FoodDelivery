using System;
using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public List<OrderInfo> OrderInfos { get; set; }

        public CustomerInfo()
        {
            OrderInfos = new List<OrderInfo>();
        }
    }
}