
using Microsoft.OpenApi.Models;
using SampleAPICall.Services;

namespace SampleAPICall
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rain Fall API", Version = "v1", 
                    Contact = new OpenApiContact() { Name = "Test", 
                        Url = new Uri("https://www.test.url.com") },
                    Description = "API that rovide rain fall reading data" });
            });

            builder.Services.AddHttpClient("RainfallAPI", client =>
            {
                client.BaseAddress = new Uri("https://environment.data.gov.uk/flood-monitoring/");
            });

            builder.Services.AddScoped<RainfallMeasurementService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rain Fall API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
