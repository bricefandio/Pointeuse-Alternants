using Pointeuse.WebApp.Services; // Assurez-vous que ce namespace est correct !

var builder = WebApplication.CreateBuilder(args);

// 🔧 Ajout du support MVC (avec contrôleurs et vues)
builder.Services.AddControllersWithViews();

// 🔗 Suppression de la connexion DbContext/SQL Server (car ce projet est maintenant un client)
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// ✅ Configuration du HttpClient pour consommer l’API
builder.Services.AddHttpClient("API", client =>
{
    // Attention : Assurez-vous que cette URL correspond bien à l'adresse de votre API !
    client.BaseAddress = new Uri("https://localhost:7124");
});

// Injection du ApiClient custom (pour encapsuler les appels HTTP)
builder.Services.AddScoped<ApiClient>();

// 🗑️ Suppression de la configuration Swagger/API Explorer (car ce n'est plus un projet API)
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pointeuse API", Version = "v1" });
// });


var app = builder.Build();

// ============================
// Configuration du pipeline HTTP
// ============================

if (app.Environment.IsDevelopment())
{
    // En environnement de dev, nous pouvons supprimer les middlewares Swagger
    // app.UseSwagger();
    // app.UseSwaggerUI(c =>
    // {
    //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pointeuse API v1");
    // });
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

// 📍 Route par défaut modifiée pour pointer vers un contrôleur/action plus pertinent (ex: Etudiants/Index)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Etudiants}/{action=Index}/{id?}");

app.Run();