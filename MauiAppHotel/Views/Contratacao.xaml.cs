using System.Globalization;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Contratacao : ContentPage
{
    private static readonly CultureInfo PtBr = new("pt-BR");
    private readonly bool carregado;
    private int adultos = 1;
    private int criancas = 0;

    private readonly List<Quarto> quartos = new()
    {
        new Quarto { Descricao = "Standard", ValorDiaria = 150 },
        new Quarto { Descricao = "Luxo", ValorDiaria = 250 },
        new Quarto { Descricao = "Suíte Master", ValorDiaria = 400 },
    };

    public Contratacao()
    {
        InitializeComponent();

        pckQuarto.ItemsSource = quartos;

        dtpCheckIn.MinimumDate = DateTime.Today;
        dtpCheckIn.Date = DateTime.Today;
        dtpCheckOut.MinimumDate = DateTime.Today.AddDays(1);
        dtpCheckOut.Date = DateTime.Today.AddDays(1);

        carregado = true;
        AtualizarResumo();
    }

    private Hospedagem Montar() => new()
    {
        Hospede = txtNome.Text?.Trim() ?? "",
        Quarto = pckQuarto.SelectedItem as Quarto,
        Adultos = adultos,
        Criancas = criancas,
        CheckIn = dtpCheckIn.Date,
        CheckOut = dtpCheckOut.Date,
    };

    private void AtualizarResumo()
    {
        if (!carregado) return;

        var h = Montar();
        lblAdultos.Text = $"Adultos: {h.Adultos}";
        lblCriancas.Text = $"Crianças: {h.Criancas}";
        lblResumo.Text = h.Quarto is null
            ? $"{h.Noites} noite(s)"
            : $"{h.Noites} noite(s) · {h.ValorTotal.ToString("C", PtBr)}";
    }

    private void OnAdultosMenos(object? sender, EventArgs e) { if (adultos > 1) adultos--; AtualizarResumo(); }
    private void OnAdultosMais(object? sender, EventArgs e) { if (adultos < 4) adultos++; AtualizarResumo(); }
    private void OnCriancasMenos(object? sender, EventArgs e) { if (criancas > 0) criancas--; AtualizarResumo(); }
    private void OnCriancasMais(object? sender, EventArgs e) { if (criancas < 4) criancas++; AtualizarResumo(); }

    private void OnAlterouValor(object? sender, EventArgs e) => AtualizarResumo();

    private void OnAlterouData(object? sender, DateChangedEventArgs e) => AtualizarResumo();

    private void OnCheckInSelecionado(object? sender, DateChangedEventArgs e)
    {
        var minimoSaida = e.NewDate.AddDays(1);
        if (dtpCheckOut.Date < minimoSaida)
            dtpCheckOut.Date = minimoSaida;
        dtpCheckOut.MinimumDate = minimoSaida;
        AtualizarResumo();
    }

    private async void OnContratarClicked(object? sender, EventArgs e)
    {
        var hospedagem = Montar();

        if (string.IsNullOrWhiteSpace(hospedagem.Hospede))
        {
            await DisplayAlert("Atenção", "Informe o nome do hóspede.", "OK");
            return;
        }
        if (hospedagem.Quarto is null)
        {
            await DisplayAlert("Atenção", "Selecione o tipo de quarto.", "OK");
            return;
        }

        // Envia os dados para a próxima tela por meio do BindingContext.
        await Navigation.PushAsync(new HospedagemContratada { BindingContext = hospedagem });
    }

    private async void OnSobreClicked(object? sender, EventArgs e)
        => await Navigation.PushAsync(new Sobre());
}
