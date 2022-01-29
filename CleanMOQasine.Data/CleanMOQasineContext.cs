using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContext: DbContext
    {
        private readonly string _connectionString = @"Server=(localdb);Database=CleanMOQasine;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
