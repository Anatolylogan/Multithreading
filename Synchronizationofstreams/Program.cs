class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(100);

        Thread user1 = new Thread(() => WithdrawMoney(account, 70));
        Thread user2 = new Thread(() => WithdrawMoney(account, 50));
        Thread user3 = new Thread(() => WithdrawMoney(account, 30));

        user1.Start();
        user2.Start();
        user3.Start();

        user1.Join();
        user2.Join();
        user3.Join();

        Console.WriteLine($"Операции завершены. Ваш баланс: {account.Balance}");
    }

    static void WithdrawMoney(BankAccount account, int amount)
    {
        account.Withdraw(amount);
    }
}

