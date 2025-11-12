using Microsoft.Maui.Controls;
using Pointeuse.Maui.Services;

namespace Pointeuse.Maui.Views;

public partial class LoginPage : ContentPage
{
    private readonly ApiClient _apiClient;
    private readonly MainPage _mainPage;

    public LoginPage(ApiClient apiClient, MainPage mainPage)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _mainPage = mainPage;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;
        LoginButton.IsEnabled = false;

        var username = UsernameEntry.Text?.Trim() ?? string.Empty;
        var password = PasswordEntry.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ShowError("Merci de renseigner le nom d'utilisateur et le mot de passe.");
            LoginButton.IsEnabled = true;
            return;
        }

        try
        {
            var ok = await _apiClient.LoginAsync(username, password);
            if (ok)
            {
                Application.Current.MainPage = new NavigationPage(_mainPage);
            }
            else
            {
                ShowError("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }
        catch (Exception)
        {
            ShowError("Une erreur est survenue lors de la connexion.");
        }
        finally
        {
            LoginButton.IsEnabled = true;
        }
    }

    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }
}
