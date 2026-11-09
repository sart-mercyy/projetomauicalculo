using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
        BindingContext = new InfoApp();
    }
}
