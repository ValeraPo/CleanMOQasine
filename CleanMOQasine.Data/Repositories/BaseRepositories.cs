using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class BaseRepositories
    {
        private static BaseRepositories instance;
        private readonly string _connectionString = @"Data Source=80.78.240.16;Initial Catalog=CleanMOQasine;
                                                    User ID=student;Password=qwe!23";
        public CleanMOQasineContext Context { get; set; }
        private BaseRepositories()
        {
            Context = new(_connectionString);
        }
        
        public static BaseRepositories getInstance()
        {
            if (instance == null)
                instance = new BaseRepositories();
            return instance;
        }
    }
}
