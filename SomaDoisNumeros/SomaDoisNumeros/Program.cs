class Program
{
    private static int numOne;
    private static int numTwo;

    static void Main()
    {
        Console.WriteLine("Insira dois valores, separados por um espaço, para as operações de soma e multiplicação:");
        var input = Console.ReadLine().Split(' ');
        numOne = Convert.ToInt32(input[0]);
        numTwo = Convert.ToInt32(input[1]);

        var productNums = 0;

        Console.WriteLine($"A soma dos dois números é: {SumAndProductTwoNums(numOne, numTwo, out productNums)}");
        Console.WriteLine($"A multiplicação dos dois números é: {productNums}");
        Console.ReadKey();
    }

    static int SumAndProductTwoNums(int numOne, int numTwo, out int productNums)
    {
        var sumNums = numOne + numTwo;
        productNums = numOne * numTwo;

        return sumNums;
    }
}