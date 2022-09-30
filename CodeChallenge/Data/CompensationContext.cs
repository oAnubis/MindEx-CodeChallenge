using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Data
{
    // This is called from the Compensation Repository to get access to the DbSet
    // Added this so I could seed the database, thus allowing me to test the Get action in the Compensation Controller
    public class CompensationContext : DbContext
    {
        public CompensationContext(DbContextOptions<CompensationContext> options) : base(options)
        {

        }

        public DbSet<Compensation> Compensation { get; set; }
    }
}