using Semana_06.Interface;
namespace Comex.Semana06.Produto;

internal class Livro : Produto, Iidentifica
{
    public string Isbn { get; }
    public int TotalDePaginas { get; }

    public Livro(string nome, string isbn, int totalDePagina) : base(nome)
    {
        Isbn = isbn;
        TotalDePaginas = totalDePagina;
    }

    public string Identificar()
    {
        return $"Nome: {Nome} ISBN: {Isbn}";
    }
}