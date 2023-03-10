using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Infrastructure.DB.Contexts;
using Neoxim.Platform.Infrastructure.DB.Repositories;
using Neoxim.Platform.Infrastructure.Systems;

namespace Neoxim.Platform.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection Infrastructure(this IServiceCollection services, IConfiguration cfg)
        {
            // ...
            // PostgreSQL
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.EnableDetailedErrors();
                var cs = cfg.GetConnectionString("PostgreSQL");
                options.UseNpgsql(cs);
            });

            //services.AddScoped(typeof(ICommandRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IQueryRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISystemClock, SystemClock>();

            return services;
        }

        /// <summary>
        /// Apply EF Migrations
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void ApplyEfMigrations(this IApplicationBuilder app)
        {
            using var ctx = app.ApplicationServices.CreateScope()
                                                   .ServiceProvider.GetRequiredService<ApplicationDbContext>();
            ctx.Database.Migrate();
        }
    }
}