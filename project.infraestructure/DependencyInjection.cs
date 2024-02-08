

using project.infraestructure.Repositories.Posts.Interfaces;
using project.infraestructure.Repositories.Posts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using project.infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace project.infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<projectContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<IPostRepository, PostRepository>();

            return services;
        }
    }
}
