using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VuelosCRUD.Models;

namespace VuelosCRUD.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        [HttpPost]
        public async Task<IActionResult> SeedRoles()
        {
            bool userExists = await _roleManager.RoleExistsAsync(StaticUserRoles.User);

            if (userExists)
            {
                return Ok("Los roles ya estaban cargados.");
            }

            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.User));

            return Ok("Los roles fueron correctamente cargados.");
        }
    }
}
