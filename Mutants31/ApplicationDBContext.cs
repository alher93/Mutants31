using Microsoft.EntityFrameworkCore;
using Mutants31.Model;

namespace Mutants31
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Mutant> MutantsHistory { get; set; }
    }
}
