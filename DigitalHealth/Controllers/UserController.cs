using Auth;
using DigitalHealth.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(RoleManager<IdentityRole<Guid>> roleManager,
                                UserManager<User> manager) : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto logDto, [FromServices] AuthService _authService)
        {

            var result = await _authService.LoginAsync(logDto);

            if (result.IsFailure)
                return BadRequest(result.Error);

            var token = result.Value;

            return Ok(token);
        }



        [HttpPost("CreateRole")]
       // [Authorize(Roles = nameof(Role.Administrator))]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (!Enum.TryParse<Role>(roleName, out _))
                return BadRequest("Invalid role");

            if (await roleManager.RoleExistsAsync(roleName))
                return Ok();

            await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
            return Ok();
        }


        [HttpPost("AddToRole")]
        [Authorize(Roles = nameof(Role.Administrator))]
        public async Task<IActionResult> AddToRole([FromQuery] string email, [FromQuery] string roleName)
        {
            if (!Enum.TryParse<Role>(roleName, true, out Role role))
                return BadRequest("Invalid role");

            var user = await manager.FindByEmailAsync(email);
            if (user is null)
                return BadRequest("User does not exist");

            var action = await manager.AddToRoleAsync(user, roleName);
            //var addClaims = await manager.AddClaimAsync(user,new System.Security.Claims.Claim { })

            if (!action.Succeeded)
                return BadRequest(action.Errors.First().Description);


            return Ok();
        }


        [HttpGet("Claims")]
        [Authorize]
        public ActionResult<IEnumerable<Claim>> CheckClaims()
        {
            var userClaims = HttpContext.User.Claims.Select(t => t.Value).ToList();

            return Ok(userClaims);
        }

        [HttpGet("AssertRole")]
        [Authorize]
        public ActionResult<bool> AssertRole(string Role)
        {

            var isInrole = HttpContext.User.IsInRole(Role);

            return Ok(isInrole);
        }

    }

}

