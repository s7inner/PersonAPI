using Microsoft.EntityFrameworkCore;
using PersonAPI.Models;

namespace PersonAPI.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }
}
