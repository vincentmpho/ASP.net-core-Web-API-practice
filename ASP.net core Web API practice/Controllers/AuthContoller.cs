using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Walk_and_Trails_of_SA_API.Models.DTO;
using Walk_and_Trails_of_SA_API.Repositories;

namespace Walk_and_Trails_of_SA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public ITokenRepository TokenRepository { get; }

        public AuthContoller(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            TokenRepository = tokenRepository;
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
        //POST: api/api/Auth/Login

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);

            //check

            if (user == null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    //Get Roles For this roles

                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        //create token
                         var jwtToken=TokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return StatusCode(StatusCodes.Status200OK, jwtToken);
                    }



                    return StatusCode(StatusCodes.Status200OK);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, "username or Password incorrect");
        }

    }
}
