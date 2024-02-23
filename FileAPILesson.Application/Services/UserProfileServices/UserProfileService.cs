using FileAPILesson.Domain.Entities.DTOs;
using FileAPILesson.Domain.Entities.Models;
using FileAPILesson.Infrastructure.Persistance;

namespace FileAPILesson.Application.Services.UserProfileServices
{
    public class UserProfileService : IUserProfileService
    {

        private readonly ApplicationDbContext _context;


        public UserProfileService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<string> CreateUserProfileAsync(UserProfileDTO userDTO, string picturePath)
        {

            var model = new UserProfile()
            {
                FullName = userDTO.FullName,
                Phone = userDTO.Phone,
                UserRole = userDTO.UserRole,
                Login = userDTO.Login,
                Password = userDTO.Password,
                PicturePath = picturePath,
            };

            await _context.Users.AddAsync(model);

            await _context.SaveChangesAsync();

            return "yaratildi";
        }

        public Task<bool> DeleteUserProfileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProfile>> GetAllUserProfileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetByIdUserProfileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> UpdateUserProfileAsync(int id, UserProfileDTO modelDTO)
        {
            throw new NotImplementedException();
        }
    }
}
