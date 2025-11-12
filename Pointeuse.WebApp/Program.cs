using Microsoft.EntityFrameworkCore;
using Pointeuse.Data;
using Microsoft.OpenApi.Models;




namespace Pointeuse.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔗 Connexion à ta base SQL Server existante
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 🔧 Ajout du support MVC (avec contrôleurs et vues)
            builder.Services.AddControllersWithViews();

            // Swagger (optionnel pour les tests API dans le navigateur)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pointeuse API", Version = "v1" });
            });

            var app = builder.Build();

            // ============================
            // Configuration du pipeline HTTP
            // ============================
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pointeuse API v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // 📍 Routes MVC classiques
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
