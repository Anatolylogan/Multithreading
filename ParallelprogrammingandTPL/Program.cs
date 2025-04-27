class Program
{
    static void Main()
    {
        Console.WriteLine("Вычисление факториалов от 1 до 10 с помощью Task и Parallel.For:");

        Parallel.For(1, 11, number =>
        {
            Task.Run(() =>
            {
                long factorial = CalculateFactorial(number);
                Console.WriteLine($"Факториал {number} = {factorial}");
            }).Wait();
        });

        Console.WriteLine("Выполнено. Нажмите Enter для выхода.");
        Console.ReadLine();
    }

    static long CalculateFactorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
