class Program
{
    static void Main(string[] args)
    {
        NumberPrinter numberPrinter = new NumberPrinter();
        ProgramBase simplePrinter = new ProgramBase();

        Thread thread1 = new Thread(new ThreadStart(numberPrinter.PrintEvenNumbers));
        Thread thread2 = new Thread(new ThreadStart(numberPrinter.PrintOddNumbers));
        Thread thread3 = new Thread(new ThreadStart(simplePrinter.PrintNumbers));

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();


        Console.WriteLine("Потоки запущены. Нажмите Enter для выхода.");
        Console.ReadLine();
    }
}
