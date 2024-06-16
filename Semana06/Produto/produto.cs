using System.Text.Json.Serialization;

namespace Comex.Semana06.Produto;

internal class Produto
{
    public Produto()
    {
    }
    public Produto(string nome)
    {
        Nome = nome;
    }
    public Produto(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }

    [JsonPropertyName("title")]
    public string Nome { get; set; }
    [JsonPropertyName("description")]
    public string Descricao { get; set; }
    [JsonPropertyName("price")]
    public float Preco_unitario { get; set; }
    public int Quantidade { get; set; }
    public string InformacaoResumida => $"Nome do produto {Nome}, sestá é a descrição {Descricao}, preço unitario {Preco_unitario}, quantidade {Quantidade}.";

}