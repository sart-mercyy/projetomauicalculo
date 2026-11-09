using MauiAppHotel.Views;

namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        UserAppTheme = AppTheme.Light;

        MainPage = new NavigationPage(new Contratacao())
        {
            BarBackgroundColor = (Color)Resources["Azul"],
            BarTextColor = Colors.White
        };
    }
}
