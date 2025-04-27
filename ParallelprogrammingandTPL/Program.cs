class Program
{
    static void Main()
    {
        Console.WriteLine("Вычисление факториалов от 1 до 10 с возможностью отмены.");
        var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        Task.Run(() =>
        {
            Console.WriteLine("Нажмите любую клавишу для отмены операций...");
            Console.ReadKey();
            cts.Cancel();
        });

        try
        {
            Parallel.For(1, 11, new ParallelOptions { CancellationToken = token }, number =>
            {
                token.ThrowIfCancellationRequested(); 
                long factorial = CalculateFactorial(number, token);
                Console.WriteLine($"Факториал {number} = {factorial}");
            });

            Console.WriteLine("Все задачи успешно выполнены.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Операция была отменена пользователем.");
        }
        finally
        {
            cts.Dispose();
        }

        Console.WriteLine("Программа завершена. Нажмите Enter для выхода.");
        Console.ReadLine();
    }

    static long CalculateFactorial(int n, CancellationToken token)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            token.ThrowIfCancellationRequested(); 
            result *= i;
            Thread.Sleep(100);
        }
        return result;
    }
}
