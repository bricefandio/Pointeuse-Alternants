using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Maui.Controls;
using Pointeuse.Maui.Models;
using Pointeuse.Maui.Services;
using QRCoder;

namespace Pointeuse.Maui.Views;

public partial class MainPage : ContentPage
{
    private readonly ApiClient _apiClient;
    private bool _loaded;

    public ObservableCollection<GroupeDto> Groupes { get; } = new();
    public ObservableCollection<PromotionDto> Promotions { get; } = new();

    public MainPage(ApiClient apiClient)
    {
        InitializeComponent();
        _apiClient = apiClient;

        // Le BindingContext donne accès à Groupes et Promotions dans le XAML
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_loaded) return;

        try
        {
            var groupes = await _apiClient.GetGroupesAsync();
            var promotions = await _apiClient.GetPromotionsAsync();

            Groupes.Clear();
            foreach (var g in groupes)
                Groupes.Add(g);

            Promotions.Clear();
            foreach (var p in promotions)
                Promotions.Add(p);

            _loaded = true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Chargement impossible : {ex.Message}", "OK");
        }
    }

    private async void OnGenerateQrCodeClicked(object sender, EventArgs e)
    {
        var nom = NomEntry.Text?.Trim();
        var prenom = PrenomEntry.Text?.Trim();
        var groupe = GroupePicker.SelectedItem as GroupeDto;
        var promotion = PromotionPicker.SelectedItem as PromotionDto;

        if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom))
        {
            await DisplayAlert("Champs requis", "Nom et prénom obligatoires.", "OK");
            return;
        }
        if (groupe is null || promotion is null)
        {
            await DisplayAlert("Champs requis", "Sélectionne le groupe et la promotion.", "OK");
            return;
        }

        try
        {
            GenerateButton.IsEnabled = false;

            var qrHash = Guid.NewGuid().ToString("N");

            var etu = new EtudiantDto
            {
                Nom = nom!,
                Prenom = prenom!,
                GroupeId = groupe.Id,
                PromotionId = promotion.Id,
                QrCodeHash = qrHash
            };

            await _apiClient.CreateEtudiantAsync(etu);

            // Génération locale du QR
            var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode(qrHash, QRCodeGenerator.ECCLevel.Q);
            var png = new PngByteQRCode(data);
            var bytes = png.GetGraphic(20);

            QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
            QrCodeLabel.IsVisible = true;
            QrCodeImage.IsVisible = true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", ex.Message, "OK");
        }
        finally
        {
            GenerateButton.IsEnabled = true;
        }
    }
}
