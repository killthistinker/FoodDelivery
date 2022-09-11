using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Models.ViewModels.PointViewModels
{
    public class PointViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckAccountName", "AccountValidation", ErrorMessage = "Логин занят")]
        public string Name { get; set; }
        
        [Display(Name = "File")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public IFormFile File { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Description { get; set; }
    }
}