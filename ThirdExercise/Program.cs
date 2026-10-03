class Program
{
    static void Main()
    {
        Console.Write("Informe um valor: ");

        if (!double.TryParse(Console.ReadLine(), out double valor))
        {
            Console.WriteLine("Foi informado um valor em formato inválido.");
            return;
        }

        Console.Write("Informe uma data de vencimento: ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataVencimento))
        {
            Console.WriteLine("Informe um valor de data válido.");
            return;
        }

        DateTime dataAtual = DateTime.UtcNow;

        if (dataVencimento >= dataAtual)
        {
            Console.WriteLine("A dívida ainda não está vencida.");
            Console.WriteLine($"Valor sem juros: R$ {valor:F2}");
            return;
        }

        int diasAtraso = (dataAtual - dataVencimento).Days;
        
        double juros = valor * 0.025 * diasAtraso;

        double valorComJuros = valor + juros;

        Console.WriteLine($"Dias em atraso: {diasAtraso}");
        Console.WriteLine($"Juros: R$ {juros:F2}");
        Console.WriteLine($"Valor final com juros: R$ {valorComJuros:F2}");
    } 
}