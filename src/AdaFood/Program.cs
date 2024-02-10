using AdaFood.Application.Interfaces;
using AdaFood.Application.Services;
using AdaFood.Infra.Interfaces;
using AdaFood.Infra.Repositories;
using AdaFood.WebAPI.Filters;

namespace AdaFood.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Repository
            builder.Services.AddSingleton<IDeliveryDriverRepository, DeliveryDriverRepository>();

            // Service
            builder.Services.AddSingleton<ServiceHelper>();
            builder.Services.AddScoped<IDeliveryDriverService, DeliveryDriverService>();
            builder.Services.AddTransient<AuthFilter>();

            // Add services to the container.

            builder.Services.AddControllers(options =>
                {
                    options.Filters.Add<ExceptionFilter>();
                });

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
