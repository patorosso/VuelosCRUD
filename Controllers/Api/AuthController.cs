using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VuelosCRUD.Areas.Identity.Data;
using VuelosCRUD.Models;

namespace VuelosCRUD.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<VuelosCRUDUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(RoleManager<IdentityRole> roleManager, UserManager<VuelosCRUDUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> SeedRoles()
        {
            bool userExists = await _roleManager.RoleExistsAsync(StaticUserRoles.User);
            bool adminExists = await _roleManager.RoleExistsAsync(StaticUserRoles.Admin);

            if (userExists && adminExists)
            {
                return Ok("Los roles ya estaban cargados.");
            }

            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Admin));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.User));

            return Ok("Los roles fueron correctamente cargados.");
        }
    }
}
