using HospitalManager.Data;
using HospitalManager.Repositorios;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<HospitalManagerDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // No método de configuração do seu serviço de serialização (por exemplo, ConfigureServices no Startup.cs)
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });


            builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            builder.Services.AddScoped<IMedicoRepositorio, MedicoRepositorio>();
            builder.Services.AddScoped<IEnfermeiroRepositorio, EnfermeiroRepositorio>();
            builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
            builder.Services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
            builder.Services.AddScoped<IConsultaRepositorio, ConsultaRepositorio>();

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
}
