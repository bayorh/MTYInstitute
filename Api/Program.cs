using Api.Extensions;
using Application.Parents.Commands.CreateParent;
using Domain.Repositories;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using Mty.Infrastructure.Repositories;

namespace Api;
public class Program
{
    public static void Main(string[] args)
    { 
        var builder = WebApplication.CreateBuilder(args);

        //not sure it will work      
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateParentCommand).Assembly));

        builder.Services.ConfigureCORs();
        builder.Services.AddScoped<IParentRepository, FakeParentRepository>();
        builder.Services.AddScoped<IUnitOfWork, FakeUnitOFWork>();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MTY API", Version = "v1" });
        });

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MTY API V1");
            });
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseForwardedHeaders(new ForwardedHeadersOptions()
        {
            ForwardedHeaders = ForwardedHeaders.All
        });
       // app.UseCors("CorsPolicy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}