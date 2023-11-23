
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Asn1.X509;
using apiqxote.Models;
using apiqxote.databaseqxote;

namespace apiqxote
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DatabaseqxoteContext>(options =>
               options.UseMySQL("Data Source=localhost;Database=databaseqxote;Uid=root;"));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntityType<Animal>();
            modelBuilder.EntityType<BioConcentration>();
            modelBuilder.EntityType<Plant>();
            modelBuilder.EntityType<Tree>().HasKey(entity => entity.TreeNr);
            modelBuilder.EntityType<TreeName>();
            modelBuilder.EntityType<Zone>();

            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() { Title = "API Docs", Version = "v1" });
            });

            builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}