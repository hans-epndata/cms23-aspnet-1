while (true)
{
    Console.Clear();
    Console.Write("Ange hur många tal som ska kontrolleras (ange ett positivt heltal): ");
    var number = int.Parse(Console.ReadLine()!);

    for (int i = 1; i <= number; i++)
    {
        string result = (i % 3, i % 5) switch
        {
            (0, 0) => "FizzBuzz",
            (0, _) => "Fizz",
            (_, 0) => "Buzz",
            _ => i.ToString(),
        };

        Console.WriteLine(result);
    }

    Console.ReadKey();
}
