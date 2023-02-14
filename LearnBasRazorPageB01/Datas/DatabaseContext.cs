using Microsoft.EntityFrameworkCore;

namespace LearnBasRazorPageB01.Datas
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {

        }


        #region dbSet for import and export data on DB
        public DbSet<Employee> Employees { get; set;}
        #endregion
    }
}
