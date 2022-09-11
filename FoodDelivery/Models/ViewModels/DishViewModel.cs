using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace FoodDelivery.Models.ViewModels
{
    public class DishViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckAccountName", "AccountValidation", ErrorMessage = "Логин занят")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public decimal Pirce { get; set; }

        public int PointId { get; set; }
    }
}