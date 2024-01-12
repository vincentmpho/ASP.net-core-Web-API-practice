using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Walk_and_Trails_of_SA_API.Models.DTO;

namespace Walk_and_Trails_of_SA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthContoller(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        //Post: api/auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName,
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            //check

            if (identityResult.Succeeded)
            {
                ///Add roles to this user
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                }

                if (identityResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, "User was registered! Please login");
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Something went wrong");

        }
    }
}
