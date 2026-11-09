namespace MauiAppHotel.Models;

public class InfoApp
{
    public string Nome { get; set; } = "App Hotel";
    public string Versao { get; set; } = AppInfo.Current.VersionString;
    public string Desenvolvedor { get; set; } = "Murilo Gomes Sartori de Oliveira";   // TODO: coloque seu nome completo
    public int Ano { get; set; } = 2026;
    public string Curso { get; set; } = "Curso Técnico em Desenvolvimento de Sistemas";
    public string Disciplina { get; set; } = "Desenvolvimento de Sistemas II";
    public string Instituicao { get; set; } = "Centro Paula Souza";
    public string Tecnologia { get; set; } = ".NET MAUI · C# · XAML";
}
