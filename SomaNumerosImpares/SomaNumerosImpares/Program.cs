var soma = 0;

for (int i = 101; i <= 199; i += 2)
{
    soma += i;
}

Console.WriteLine($"A soma dos números ímpares entre 100 e 200 é: {soma}");
Console.ReadKey();