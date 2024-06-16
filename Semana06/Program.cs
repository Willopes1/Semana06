using Comex.Semana06.Produto;
using Comex.Semana06.Menu;

internal class Program
{
    private static void Main(string[] args)
    {
        Cliente cliente = new Cliente("Cliente 1", "111.222.333-44", "email@teste.com.br");

        Produto produto = new Produto("Produto 1", "descrição do produto")
        {
            Preco_unitario = 2.30f,
            Quantidade = 100,
        };

        Menu menu = new();
        menu.Opcoes();
    }
}