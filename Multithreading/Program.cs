class Program
{
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(PrintNumbers);
        Thread thread2 = new Thread(PrintEven);
        Thread thread3 = new Thread(PrintOdd);
       
        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Потоки запущены. Нажмите Enter для выхода.");
        Console.ReadLine();
    }

    static void PrintNumbers()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(500);
        }
    }

    static void PrintEven()
    {
        for (int i = 0; i <= 10; i += 2)
        {
            Console.WriteLine($"Чётное: {i}");
            Thread.Sleep(500);
        }
    }

    static void PrintOdd()
    {
        for (int i = 1; i < 10; i += 2)
        {
            Console.WriteLine($"Нечётное: {i}");
            Thread.Sleep(500);
        }
    }
}


