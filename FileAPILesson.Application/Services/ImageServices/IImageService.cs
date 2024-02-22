using FileAPILesson.Domain.Entities.Models;

namespace FileAPILesson.Application.Services.ImageService
{
    public interface IImageService
    {
        public Task<Image> CreateImage(IFormFile);
    }
}
