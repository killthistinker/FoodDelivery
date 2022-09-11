using System.Collections.Generic;
using FoodDelivery.Models.ViewModels.PointViewModels;

namespace FoodDelivery.Models.ViewModels.IndexViewModels
{
    public class IndexPointViewModel
    {
        public IEnumerable<Point> Points { get; set; }
        public PointViewModel Model { get; set; }
    }
}