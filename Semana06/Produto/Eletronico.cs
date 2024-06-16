namespace Comex.Semana06.Produto;

internal class Eletronico : Produto
{
    public int Voltagem { get; }
    public int Potencia { get; }

    public Eletronico(string nome, int voltagem, int potencia) : base(nome)
    {
        Voltagem = voltagem;
        Potencia = potencia;
    }
}