using FileAPILesson.API.ExternalServices;
using FileAPILesson.Application.Services.UserProfileServices;
using FileAPILesson.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileAPILesson.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserProfileService _userService;

        public UserController(IUserProfileService userProfileService, IWebHostEnvironment env)
        {
            _userService = userProfileService;
            _env = env;

        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<string>> CreateUser([FromForm] UserProfileDTO userProfileDTO, IFormFile picture)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(picture);
            
            var result = _userService.CreateUserProfileAsync(userProfileDTO, picturePath).Result;
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult PostForm(UserProfileDTO userProfileDTO)
        {
            return Ok(userProfileDTO);
        }


    }
}
