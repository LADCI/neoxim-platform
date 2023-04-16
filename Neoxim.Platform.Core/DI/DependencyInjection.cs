using Microsoft.Extensions.DependencyInjection;
using Neoxim.Platform.Core.Services;
using Neoxim.Platform.Core.Services.Impl;

namespace Neoxim.Platform.Core.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection Core(this IServiceCollection services)
        {
            // ...

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IFolderService, FolderService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}