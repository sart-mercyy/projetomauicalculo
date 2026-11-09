namespace MauiAppHotel.Models;

public class Hospedagem
{
    public string Hospede { get; set; } = "";
    public Quarto? Quarto { get; set; }
    public int Adultos { get; set; }
    public int Criancas { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    public int Noites => Math.Max((CheckOut.Date - CheckIn.Date).Days, 0);

    // Diária cobrada por adulto; crianças pagam 50%.
    public double ValorTotal =>
        Quarto is null ? 0 : Noites * Quarto.ValorDiaria * (Adultos + 0.5 * Criancas);

    public string QuartoDescricao => Quarto?.Descricao ?? "-";
}
