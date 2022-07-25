using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FoodManager.Application.DTO.FileUpload;
using FoodManager.Application.Interfaces.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FoodManager.Infrastructure.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly CloudinaryConfig _config;
        private readonly Cloudinary _cloudinary;

        public FileUploadService(IOptions<CloudinaryConfig> config)
        {
            _config = config.Value;
            Account account = new Account(_config.CloudName, _config.ApiKey, _config.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public DeletionResult DeleteAvatar(string publicId)
        {
            return _cloudinary.Destroy(new DeletionParams(publicId) { ResourceType = ResourceType.Image });
        }

        public UploadImageResponseDto UploadAvatar(IFormFile file)
        {
            var imageUploadResult = new ImageUploadResult();
            using (var fs = file.OpenReadStream())
            {
                var imageUploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, fs),
                    Transformation = new Transformation().Width(300).Height(300).Crop("fill").Gravity("face")
                };
                imageUploadResult = _cloudinary.Upload(imageUploadParams);
            }
            return new UploadImageResponseDto
            {
                PublicId = imageUploadResult.PublicId,
                AvatarUrl = imageUploadResult.Url.ToString()
            };
        }
    }
}
