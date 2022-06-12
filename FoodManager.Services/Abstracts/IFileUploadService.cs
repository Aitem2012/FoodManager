using FoodManager.Application.DTO.FileUpload;
using Microsoft.AspNetCore.Http;

namespace FoodManager.Services.Abstracts
{
    public interface IFileUploadService
    {
        public UploadImageResponseDto UploadAvatar(IFormFile file);
        public CloudinaryDotNet.Actions.DeletionResult DeleteAvatar(string publicId);
    }
}
