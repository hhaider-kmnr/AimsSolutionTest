using Microsoft.AspNetCore.Authorization;

namespace AimsSolutionTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.ResolveRepositories();
            builder.Services.ResolveMapper();
            builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Api");
                c.RoutePrefix = "swagger";
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(c =>
            {
                c.MapRazorPages();
                c.MapControllers();
            });

            app.Run();
        }
    }
}