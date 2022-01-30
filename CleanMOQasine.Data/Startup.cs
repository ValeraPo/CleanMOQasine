using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<CleanMOQasineContext>();
    }
}
