using Api.DTO;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> usermanager;

        public AccountController(UserManager<AppUser> usermanager)
        {
            this.usermanager = usermanager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewUser(UserDto user)
        {
            AppUser NewUser = new()
            {
                UserName = user.UserName,
                Email = user.Email,
            };

            IdentityResult result = await usermanager.CreateAsync(NewUser, user.Password);
            if (result.Succeeded)
            {
                return Ok("Succeded...");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    return BadRequest(item.Description);
                }
            }
            return BadRequest("Failed...");

        }


        [HttpPost("login/")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                if (login != null)
                {
                    var user = await usermanager.FindByNameAsync(login.UserName);
                    if (user != null)
                    {
                        if (await usermanager.CheckPasswordAsync(user, login.Password))
                            return Ok("Logined and take Token...");
                        else
                            return Unauthorized();
                    }
                    else
                        return BadRequest("User Invalid...");
                }
                else
                    return BadRequest("Login User inValid...");
            }
            else
                return BadRequest();



        }

    }
}
