using Microsoft.EntityFrameworkCore;
using RequestProblem.Models;

namespace RequestProblem.Repositories
{
    public class ProblemMgmtContext : DbContext
    {
        public ProblemMgmtContext(DbContextOptions<ProblemMgmtContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        public DbSet<Problems> Problems { get; set; }
        public DbSet<Applications> Applications { get; set; }
    }
}
