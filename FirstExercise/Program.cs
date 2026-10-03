using System.Text.Json;

public class Venda
{
    public required string Vendedor { get; set; }
    public double Valor { get; set; }
}

public class Dados
{
    public required List<Venda> Vendas { get; set; }
}

class Program
{
    static void Main()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        string file = File.ReadAllText("vendas.json");
        Dictionary<string, double> comissoes = [];

        Dados dados = JsonSerializer.Deserialize<Dados>(file, options) ?? throw new JsonException("É preciso haver vendas feitas.");

        foreach (var venda in dados.Vendas)
        {
            double percentual = 0;

            if(venda.Valor >= 500)
                percentual = 0.05;
            else if (venda.Valor >= 100)
                percentual = 0.01;

            double comissao = venda.Valor * percentual;

            if(!comissoes.ContainsKey(venda.Vendedor))
                comissoes[venda.Vendedor] = 0;

            comissoes[venda.Vendedor] += comissao;
        }

        foreach(var item in comissoes)
        {
            Console.WriteLine($"{item.Key}: R$ {item.Value:F2}");
        }
    }
}