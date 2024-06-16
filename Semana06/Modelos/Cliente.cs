using Semana_06.Interface;

namespace Comex.Semana06.Produto;
internal class Cliente : Iidentifica
{
    public Cliente(string nome, string cpf, string email)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
    }

    public string Nome { get; }
    public string Cpf { get; }
    public string Email { get; }
    public string Profissao { get; set; }
    public string Telefone { get; set; }
    public Endereco Endereco { get; set; }

    public void DadosDoCliente()
    {
        Console.WriteLine($"O cliente {Nome} reside na cidade de {Endereco.Cidade}, localizado na rua {Endereco.Rua}");
    }

    public string Identificar()
    {
        return $"Nome: {Nome} CPF: {Cpf}";

    }

}
