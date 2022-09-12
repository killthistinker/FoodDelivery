using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Services.Abstractions;
using MailKit.Net.Smtp;
using MimeKit;

namespace FoodDelivery.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(AddOrderViewModel model)
        {
            var emailMessage = new MimeMessage();
            
            emailMessage.From.Add(new MailboxAddress("Доставка еды", "killthistinker@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", model.Email));

            emailMessage.Subject = "Составлен заказ";

            StringBuilder message = new StringBuilder();
            message.Append($"Заказ по адресу {model.Email} составлен. Адрес доставки: {model.Address}. Детали заказа: ");
            foreach (var dish in model.Dishes)
            {
                message.Append($"Блюдо: {dish.Dish.Name}. Количество: {dish.DishCount}");
            }

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message.ToString()
            };

            await SendEmailAsync(emailMessage);
        }
        
        private async Task SendEmailAsync(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync("killthistinker@mail.ru", "wDZeMYAr04cDPfrEfaP2");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}