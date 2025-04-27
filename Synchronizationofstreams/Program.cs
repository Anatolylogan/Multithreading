class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(150);

        Thread user1 = new Thread(() => account.Withdraw(70));
        Thread user2 = new Thread(() => account.Withdraw(90));

        user1.Start();
        user2.Start();

        user1.Join();
        user2.Join();

        Console.WriteLine("Все операции завершены.");
    }
}