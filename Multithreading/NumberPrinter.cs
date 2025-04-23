public class NumberPrinter
{
    public void PrintEvenNumbers()
    {
        for (int i = 0; i <= 10; i += 2)
        {
            Console.WriteLine($"Чётное: {i}");
            Thread.Sleep(500);
        }
    }

    public void PrintOddNumbers()
    {
        for (int i = 1; i < 10; i += 2)
        {
            Console.WriteLine($"Нечётное: {i}");
            Thread.Sleep(500);
        }
    }
}
