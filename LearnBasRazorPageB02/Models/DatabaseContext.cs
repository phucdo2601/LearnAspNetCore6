using Microsoft.EntityFrameworkCore;

namespace LearnBasRazorPageB02.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        #region dbSet for import or export data on db
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        #endregion
    }
}
