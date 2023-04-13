using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Areas.Identity.Data;

// Add profile data for application users by adding properties to the VuelosCRUDUser class
public class VuelosCRUDUser : IdentityUser
{
    [PersonalData]
    [StringLength(maximumLength: 50)]
    public string CustomName { get; set; } = null!;


}

