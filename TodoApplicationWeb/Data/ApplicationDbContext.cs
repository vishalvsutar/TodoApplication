using Microsoft.EntityFrameworkCore;
using TodoApplicationWeb.Models;

namespace TodoApplicationWeb.Data
{
    public class ApplicationDbContext : DbContext     
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> TodoTasks{ get; set; }
    }
}
 