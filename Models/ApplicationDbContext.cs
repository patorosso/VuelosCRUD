using Microsoft.EntityFrameworkCore;

namespace VuelosCRUD.Models
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
