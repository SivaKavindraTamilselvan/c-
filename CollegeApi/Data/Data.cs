using Microsoft.EntityFrameworkCore;
using CollegeApi.Models;

namespace CollegeApi.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}