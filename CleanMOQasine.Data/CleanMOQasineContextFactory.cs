using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContextFactory : IDesignTimeDbContextFactory<CleanMOQasineContext>
    {
        private readonly string _connectionString = @"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Initial Catalog=CleanMOQasine;Integrated Security=True";
        public CleanMOQasineContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CleanMOQasineContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new CleanMOQasineContext(optionsBuilder.Options);
        }
    }
}
