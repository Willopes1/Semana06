namespace Semana_06.API

{
    internal class ClienteApi
    {
        HttpClient client = new HttpClient();

        public async Task<string> conexao()
        {
            try
            {
                string resultado = await client.GetStringAsync("https://fakestoreapi.com/products");
                return resultado;
            }
            catch (Exception ex)
            {
                return $"Falha na conexão: {ex.Message}";
            }

        }
    }
}