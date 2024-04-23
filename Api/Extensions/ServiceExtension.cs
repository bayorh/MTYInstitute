using Application.Parents.Commands.CreateParent;
using Domain.Repositories;
using Mty.Infrastructure.Repositories;

namespace Api.Extensions;

public static  class ServiceExtension
{
    public static void ConfigureCORs(this IServiceCollection services) => services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

    public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(
        option =>
        {
        });


    /* public static void ConfigureLoggerService(this IServiceCollection services) =>
         services.AddSingleton<ILoggerManager, LoggerManager>();*/


    /* public static void ConfigureServiceManager(this IServiceCollection services) =>
         services.AddScoped<IServiceManager, ServiceManager>();
     public static void ConfigureSqlContext(this IServiceCollection services,
         IConfiguration configuration) =>
         services.AddDbContext<RepositoryContext>(opts =>
             opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));*/


}
