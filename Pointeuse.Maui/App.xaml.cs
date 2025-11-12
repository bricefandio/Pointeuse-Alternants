using Pointeuse.Maui.Services;
using Pointeuse.Maui.Views;

namespace Pointeuse.Maui;

public partial class App : Application
{
    public App(LoginPage loginPage)
    {
        InitializeComponent();

        // Navigation MAUI classique
        MainPage = new NavigationPage(loginPage);
    }
}
