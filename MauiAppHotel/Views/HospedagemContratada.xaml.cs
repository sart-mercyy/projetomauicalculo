namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    private async void OnNovaReservaClicked(object? sender, EventArgs e)
        => await Navigation.PopAsync();
}
