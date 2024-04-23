using Api.Extensions;
using Application.Parents.Commands.CreateParent;
using Domain.Repositories;
using Mty.Infrastructure.Repositories;

namespace Api;
public class Program
{
    public static void Main(string[] args)
    { 
        var builder = WebApplication.CreateBuilder(args);

        //not sure it will work      
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateParentCommandHandler).Assembly));

        builder.Services.ConfigureCORs();
        builder.Services.AddScoped<IParentRepository, FakeParentRepository>();
        builder.Services.AddScoped<IUnitOfWork, FakeUnitOFWork>();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}