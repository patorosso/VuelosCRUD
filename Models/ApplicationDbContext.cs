using Microsoft.EntityFrameworkCore;

namespace VuelosCRUD.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



    }
}
