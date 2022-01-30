using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContextFactory : IDesignTimeDbContextFactory<CleanMOQasineContext>
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-16PSAEB;Initial Catalog=EbaniMenjaDrobjuBratan;Integrated Security=True";
        public CleanMOQasineContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CleanMOQasineContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new CleanMOQasineContext(optionsBuilder.Options);
        }
    }
}
