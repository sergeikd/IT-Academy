using System.Data.Entity;

namespace ASP.Exam.DalEfCodeFirst
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Details> Details { get; set; }
    }
}
