using FoodManager.Application.DTO.FileUpload;
using Microsoft.AspNetCore.Http;

namespace FoodManager.Application.Interfaces.Abstracts
{
    public interface IFileUploadService
    {
        public UploadImageResponseDto UploadAvatar(IFormFile file);
        public CloudinaryDotNet.Actions.DeletionResult DeleteAvatar(string publicId);
    }
}
