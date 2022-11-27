using Microsoft.EntityFrameworkCore;
using PersonAPI.Models;

#nullable disable

namespace PersonAPI.DatabaseContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PersonType> PersonType { get; set; }
    }
}
