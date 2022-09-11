using System;
using System.IO;
using System.Threading.Tasks;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.PointViewModels;
using FoodDelivery.Services.Abstractions;
using Microsoft.Extensions.Hosting;

namespace FoodDelivery.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IDefaultUserImageAvatar _imagePathProvider;
        private readonly UploadService _uploadService;
        private readonly IHostEnvironment _environment;

        public ImageUploadService(IDefaultUserImageAvatar imagePathProvider, UploadService uploadService, IHostEnvironment environment)
        {
            _imagePathProvider = imagePathProvider;
            _uploadService = uploadService;
            _environment = environment;
        }
        
        public async Task CreateAsync(PointViewModel entity, string userName)
        {
            string imagePath;
            if (entity.File is null)
                imagePath = _imagePathProvider.GetPathToDefaultImage();
            
            else
            {
                string dirPath = Path.Combine(_environment.ContentRootPath, $"wwwroot\\images\\pointImages\\{entity.Name}");
                string guid = Guid.NewGuid().ToString();
                string fileName = $"{guid + entity.File.FileName}";
                await _uploadService.UploadAsync(dirPath, fileName, entity.File);
                imagePath = $"images\\pointImages\\{entity!.Name}\\{fileName}";
            }

            entity.ImagePath = imagePath;
        }
    }
}