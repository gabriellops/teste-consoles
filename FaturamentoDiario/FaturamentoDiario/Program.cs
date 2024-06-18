using FaturamentoDiario;
using System.Text.Json;


class Program
{
    private static List<decimal> heap = new();
    private static decimal minValue = decimal.MaxValue;

    static void Main()
    {
        // Com hardcode ficaria assim: C:\programacao\target-test-jun\FaturamentoDiario\FaturamentoDiario\Dados.cs
        var path = @"dados.json";
        List<Dados> data = DeserializeJson(path);

        var totalRevenue = 0.00m;
        var countDaysWithRevenue = 0;

        foreach (var dado in data)
        {
            if (dado.Valor > 0)
            {
                Insert(dado.Valor);

                totalRevenue += dado.Valor;
                countDaysWithRevenue++;
            }
        }

        var annualAverage = totalRevenue / countDaysWithRevenue;

        Console.WriteLine($"O menor valor do faturamento é: R${minValue:0.00}");
        Console.WriteLine($"O maior valor do faturamento é: R${MaxValue():0.00}");
        Console.WriteLine($"Dias com faturamento diário acima da média anual são: {DaysAboveAvarage(annualAverage)} dias");

        Console.ReadKey();
    }

    static List<Dados> DeserializeJson(string path)
    {
        using var json = File.OpenRead(path);
        List<Dados> values = JsonSerializer.Deserialize<List<Dados>>(json);

        return values;
    }

    static void Insert(decimal value)
    {
        heap.Add(value);
        
        if (value < minValue)
            minValue = value;

        var i = heap.Count - 1;
        var p = Parent(i);

        while (i > 0 && heap[i] > heap[p])
        {
            Swap(i, p);
            i = p;
            p = Parent(i);
        }
    }

    static int Parent(int nodeIndex)
        => nodeIndex == 0 ? - 1 : (nodeIndex - 1) / 2;
     
    static void Swap(int i, int p)
    {
        var tempSwap = heap[i];
        heap[i] = heap[p];
        heap[p] = tempSwap;
    }

    static decimal MaxValue()
    {
        var result = heap[0];

        return result;
    }

    public static decimal DaysAboveAvarage(decimal annualAverage)
    {
        var daysAboveAvarege = 0;

        foreach (var value in heap)
        {
            if (value > annualAverage)
                daysAboveAvarege++;
        }

        return daysAboveAvarege;
    }
}