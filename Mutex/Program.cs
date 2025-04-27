class Program
{
    static Mutex mutex = new Mutex();

    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            int threadId = i; 
            Thread thread = new Thread(() => WriteToFile(threadId));
            thread.Start();
        }

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }

    static void WriteToFile(int threadId)
    {
        Console.WriteLine($"Поток {threadId} ожидает доступ к файлу...");

        mutex.WaitOne(); 
        try
        {
            Console.WriteLine($"Поток {threadId} начал запись в файл...");
       
            File.AppendAllText("output.txt", $"Поток {threadId} записал данные в {DateTime.Now}");

            Thread.Sleep(1000); 
            Console.WriteLine($"Поток {threadId} завершил запись.");
        }
        finally
        {
            mutex.ReleaseMutex(); 
        }
    }
}
