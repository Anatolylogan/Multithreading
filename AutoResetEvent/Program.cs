class Program
{
    static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    static void Main(string[] args)
    {
        Thread firstThread = new Thread(FirstOperation);

        Thread secondThread = new Thread(SecondOperation);

        firstThread.Start();
        secondThread.Start();

        firstThread.Join();
        secondThread.Join();

        Console.WriteLine("Оба потока завершены.");
    }

    static void FirstOperation()
    {
        Console.WriteLine("1-ый поток: Начинаю длительную операцию...");
        Thread.Sleep(3000); 
        Console.WriteLine("1-ый поток: Операция завершена. Отправляю сигнал 2-ому потоку.");

        autoResetEvent.Set(); 
    }

    static void SecondOperation()
    {
        Console.WriteLine("2-ой поток: Жду сигнала от 1-ого потока...");
        autoResetEvent.WaitOne();

        Console.WriteLine("2-ой поток: Получен сигнал. Начинаю выполнение работы.");
    }
}
