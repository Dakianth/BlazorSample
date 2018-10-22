using System.Threading.Tasks;
using BlazorSpa.Server.Contracts;
using BlazorSpa.Server.Extensions;
using BlazorSpa.Shared;
using BlazorSpa.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSpa.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenService tokenService;
        private readonly UserManager<IdentityUser> userManager;

        public TokenController(IJwtTokenService tokenService, UserManager<IdentityUser> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] TokenViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userManager.FindByEmailAsync(vm.Email);
            var correctUser = await userManager.CheckPasswordAsync(user, vm.Password);

            if (!correctUser)
                return BadRequest("Username or password is incorrect");

            string token = GenerateToken(vm.Email);
            return Ok(new { token });
        }

        private string GenerateToken(string email)
        {
            string token = tokenService.BuildToken(email);
            return token;
        }

        [HttpPost]
        public async Task<ActionResult> Registration([FromBody] TokenViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await userManager.CreateAsync(new IdentityUser
            {
                UserName = vm.Email,
                Email = vm.Email
            }, vm.Password);

            if (!result.Succeeded)
                return StatusCode(500);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Info()
        {
            var user = await userManager.GetJwtUserAsync(HttpContext.User);
            if (user == null)
                return BadRequest();

            return Ok(new User { Name = user.UserName, Email = user.Email });
        }
    }
}