using FileAPILesson.API.ExternalServices;
using FileAPILesson.Domain.Entities.DTOs;
using FileAPILesson.Domain.Entities.Models;
using FileAPILesson.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPILesson.Application.Services.UserProfileServices
{
    public class UserProfileService : IUserProfileService
    {

        private readonly ApplicationDbContext _context;
     

        public UserProfileService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<UserProfileDTO> CreateUserProfileAsync(UserProfileDTO userDTO)
        {
            UserProfileExternalService obj = new UserProfileExternalService();

            var model = new UserProfile()
            {
                FullName = userDTO.FullName,
                Phone = userDTO.Phone,
                UserRole = userDTO.UserRole,
                Login = userDTO.Login,
                Password = userDTO.Password,
                PicturePath = await obj.AddPictureAndGetPath(userDTO.Picture),
            };

            _context.Users.Add(model);

            await _context.SaveChangesAsync();

            return userDTO;
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
