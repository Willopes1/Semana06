namespace Comex.Semana06.Menu;
using Comex.Semana06.Produto;
using Semana_06.API;
using System.Text.Json;

internal class Menu
{
    List<Produto> listaDeProdutos = new();

    void ExibirLogo()
    {
        Console.WriteLine(@"
    
────────────────────────────────────────────────────────────────────────────────────────
─██████████████─██████████████─██████──────────██████─██████████████─████████──████████─
─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██████████████░░██─██░░░░░░░░░░██─██░░░░██──██░░░░██─
─██░░██████████─██░░██████░░██─██░░░░░░░░░░░░░░░░░░██─██░░██████████─████░░██──██░░████─
─██░░██─────────██░░██──██░░██─██░░██████░░██████░░██─██░░██───────────██░░░░██░░░░██───
─██░░██─────────██░░██──██░░██─██░░██──██░░██──██░░██─██░░██████████───████░░░░░░████───
─██░░██─────────██░░██──██░░██─██░░██──██░░██──██░░██─██░░░░░░░░░░██─────██░░░░░░██─────
─██░░██─────────██░░██──██░░██─██░░██──██████──██░░██─██░░██████████───████░░░░░░████───
─██░░██─────────██░░██──██░░██─██░░██──────────██░░██─██░░██───────────██░░░░██░░░░██───
─██░░██████████─██░░██████░░██─██░░██──────────██░░██─██░░██████████─████░░██──██░░████─
─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░██──██░░░░██─
─██████████████─██████████████─██████──────────██████─██████████████─████████──████████─
────────────────────────────────────────────────────────────────────────────────────────
    
    ");
        Console.WriteLine("Bem vindo ao projeto Comex!");
    }

    void ExibirTitulo(string titulo)
    {
        int qtdLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
        Console.WriteLine($"{asteriscos}\n{titulo}\n{asteriscos}");

    }

    public void Opcoes()
    {
        Console.Clear();
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para cadastrar Produto");
        Console.WriteLine("Digite 2 para listar os produtos");
        Console.WriteLine("Digite 3 para lista de produtos externo");
        Console.WriteLine("Digite 4 para sair");
        Console.Write("\nDigite a sua opção: ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);

        switch (opcaoEscolhida)
        {
            case 1:
                CadastrarProduto();
                break;
            case 2:
                ListarProdutos();
                break;
            case 3:
                BuscaProdutoExterna();
                break;
            case 4:
                Console.WriteLine($"Precione 'Enter' para encerrar");
                break;
            default:
                Console.WriteLine("Opção invalida");
                Console.WriteLine("Digite 'Enter' para retornar ao menu");
                Console.ReadKey();
                Opcoes();
                break;
        }
    }

    private void CadastrarProduto()
    {
        Console.Clear();
        ExibirTitulo("Cadastro de Produto:");
        Console.Write("\nDigite o nome do produto: ");
        string nome = Console.ReadLine()!;
        Console.Write("Digite a descrição: ");
        string descricao = Console.ReadLine()!;
        Console.Write("Digite o preço: R$ ");
        float preco = float.Parse(Console.ReadLine()!);
        Console.Write("Digite a quantidade: ");
        int quantidade = int.Parse(Console.ReadLine()!);

        Produto produto = new Produto(nome, descricao)
        {
            Preco_unitario = preco,
            Quantidade = quantidade
        };

        CadastrarListaDeProdutos(produto);
        Opcoes();
    }
    private void CadastrarListaDeProdutos(Produto produto)
    {
        listaDeProdutos.Add(produto);
    }

    private void ListarProdutos()
    {
        Console.Clear();
        ExibirTitulo("Exibindo os Produtos cadastrados:");
        foreach (var produto in listaDeProdutos)
        {
            Console.WriteLine(
            $"Nome: {produto.Nome}\n" +
            $"Descrição: {produto.Descricao}\n" +
            $"Preço: R$ {produto.Preco_unitario}\n" +
            $"Quantidade: {produto.Quantidade}\n"
            );
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menur principal");
        Console.ReadKey();
        Opcoes();
    }

    public void BuscaProdutoExterna()
    {
        Console.Clear();
        ExibirTitulo("Lista de Produtos Externo:");
        ClienteApi requisicao = new ClienteApi();
        var resultado = requisicao.conexao().Result;
        var listaDeProdutos = JsonSerializer.Deserialize<List<Produto>>(resultado)!;
        foreach (var produto in listaDeProdutos)
        {
            Console.WriteLine($"Produto: {produto.Nome}\n" +
            $"Descrição: {produto.Descricao}\n" +
            $"Preço: {produto.Preco_unitario}\n");
        }
        Console.ReadKey();
        Opcoes();

    }
}
