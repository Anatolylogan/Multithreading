class Program
{
    static Semaphore parkingSemaphore = new Semaphore(3, 3);

    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            int carId = i;
            Thread carThread = new Thread(() => TryToPark(carId));
            carThread.Start();
        }

        Console.ReadLine();
    }

    static void TryToPark(int carId)
    {
        Console.WriteLine($"Машина {carId} подъехала к парковке и ждет свободное место.");

        parkingSemaphore.WaitOne();

        Console.WriteLine($"Машина {carId} припарковалась.");


        Thread.Sleep(new Random().Next(2000, 5000));

        Console.WriteLine($"Машина {carId} покидает парковку.");

        parkingSemaphore.Release();
    }
}
