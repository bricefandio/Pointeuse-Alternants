using Pointeuse.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Ajout du support MVC (avec contrôleurs et vues)
builder.Services.AddControllersWithViews();

// ✅ Configuration du HttpClient pour consommer l’API
builder.Services.AddHttpClient("API", client =>
{
    // Attention : Assurez-vous que cette URL correspond bien à l'adresse de votre API !
    client.BaseAddress = new Uri("https://localhost:7124");
});

// Injection du ApiClient custom (pour encapsuler les appels HTTP)
builder.Services.AddScoped<ApiClient>();

// ⚙️ Activer les services de session (IMPORTANT)
builder.Services.AddSession(options =>
{
    // Configurer le timeout de la session (par exemple, 20 minutes)
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// ============================
// Configuration du pipeline HTTP
// ============================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 📍 AJOUT : Utiliser le middleware de session (Doit être avant UseAuthorization)
app.UseSession();

app.UseAuthorization();

// 📍 Route par défaut modifiée pour pointer vers le contrôleur d'authentification
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();