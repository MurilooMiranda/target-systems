using System.Text.Json;

public enum TipoMovimentacao
{
    Entrada,
    Saida
}

public class Produto
{
    public int CodigoProduto { get; set; }
    public required string DescricaoProduto { get; set; }
    public int Estoque { get; set; }
}

public class EstoqueData
{
    public required List<Produto> Estoque { get; set; }
}

public class Movimentacao
{
    public int Id { get; set; }
    public TipoMovimentacao Tipo { get; set; }
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; }
}

class Program
{
    static void Main()
    {
        try
        {
            string file = File.ReadAllText("estoque.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            EstoqueData dados = JsonSerializer.Deserialize<EstoqueData>(file, options) ?? throw new JsonException("É necessário que haja estoque.");

            int proximoId = 1;

            Console.WriteLine("Produtos disponíveis:");

            foreach (var produto in dados.Estoque)
            {
                Console.WriteLine(
                    $"{produto.CodigoProduto} - " +
                    $"{produto.DescricaoProduto} - " +
                    $"Estoque: {produto.Estoque}"
                );
            }

            Console.Write("\nCódigo do produto: ");
            if (!int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.WriteLine("Foi informado um valor em formato inválido.");
                return;
            }

            Produto? produtoSelecionado = dados.Estoque
                .FirstOrDefault(p => p.CodigoProduto == codigo);

            if (produtoSelecionado == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine("\n1 - Entrada");
            Console.WriteLine("2 - Saída");
            Console.Write("Tipo de movimentação: ");

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Foi informado um valor em formato inválido.");
                return;
            }

            if (opcao < 1 || opcao > 2)
            {
                Console.WriteLine("Tipo de movimentação inválido.");
                return;
            }

            TipoMovimentacao tipo = (TipoMovimentacao)(opcao - 1);

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade))
            {
                Console.WriteLine("Foi informado um valor em formato inválido.");
                return;
            }

            if (quantidade <= 0)
            {
                Console.WriteLine("A quantidade deve ser maior que zero.");
                return;
            }

            if (tipo == TipoMovimentacao.Saida && quantidade > produtoSelecionado.Estoque)
            {
                Console.WriteLine("Quantidade insuficiente em estoque.");
                return;
            }

            if (tipo == TipoMovimentacao.Entrada)
            {
                produtoSelecionado.Estoque += quantidade;
            }
            else
            {
                produtoSelecionado.Estoque -= quantidade;
            }

            Movimentacao movimentacao = new Movimentacao
            {
                Id = proximoId,
                Tipo = tipo,
                CodigoProduto = codigo,
                Quantidade = quantidade
            };

            string dadosAtualizados = JsonSerializer.Serialize(dados, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("estoque.json", dadosAtualizados);

            Console.WriteLine("\nMovimentação realizada!");
            Console.WriteLine($"ID: {movimentacao.Id}");
            Console.WriteLine($"Tipo: {movimentacao.Tipo}");
            Console.WriteLine($"Produto: {produtoSelecionado.DescricaoProduto}");
            Console.WriteLine($"Quantidade: {movimentacao.Quantidade}");
            Console.WriteLine($"Estoque final: {produtoSelecionado.Estoque}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Arquivo estoque.json não encontrado.");
        }
        catch (JsonException)
        {
            Console.WriteLine("O arquivo JSON é inválido.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Foi informado um valor em formato inválido.");
        }
    }
}