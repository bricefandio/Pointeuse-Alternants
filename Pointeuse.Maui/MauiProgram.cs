using Microsoft.Extensions.Logging;
using Pointeuse.Maui.Services;
using Pointeuse.Maui.Views;

namespace Pointeuse.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(f => f.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

        builder.Services.AddHttpClient("API", c =>
        {
            c.BaseAddress = new Uri("https://localhost:7124");
        });

        builder.Services.AddSingleton<ApiClient>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<LoginPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
