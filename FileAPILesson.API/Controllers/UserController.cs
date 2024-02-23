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
        public async Task<IActionResult> CreateUser([FromForm] UserProfileDTO userProfileDTO)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            userProfileDTO.Path = await service.AddPictureAndGetPath(userProfileDTO.Picture);
            
            var result = _userService.CreateUserProfileAsync(userProfileDTO);
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> CreateUserJson([FromBody] UserProfileDTO userProfileDTO)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            userProfileDTO.Path = await service.AddPictureAndGetPath(userProfileDTO.Picture);

            var result = _userService.CreateUserProfileAsync(userProfileDTO);
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult PostForm([FromForm] string value, IFormFile file)
        {
            return Ok(value);
        }


    }
}
