using Centralizador2023.ComunicacionSync.http;
using Centralizador2023.Repositorios;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace Centralizador2023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson( s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<InstitutoXDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("InstitutoProd")));
            builder.Services.AddHttpClient<ICampusHistorialCliente, ImplCampusHistorialCliente>();
            builder.Services.AddScoped<IEstudianteRepository,ImplEstudianteRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}