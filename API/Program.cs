using AtendimentoMedico.Infraestructure.Context;
using AtendimentoMedico.Application.Interfaces;
using AtendimentoMedico.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.UseCases;
using Infrastructure.Repositories;

namespace AtendimentoMedico.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();


        string? MySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); 
        builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(MySqlConnection, ServerVersion.AutoDetect(MySqlConnection)));

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();

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
