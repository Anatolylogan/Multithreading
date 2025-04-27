class BankAccount
{
    private object locker = new object();
    private int balance;

    public BankAccount(int initialBalance)
    {
        balance = initialBalance;
    }

    public void Withdraw(int amount)
    {
        bool lockTaken = false;
        try
        {
            Monitor.Enter(locker, ref lockTaken); 
            if (balance >= amount)
            {
                Console.WriteLine($"Снимаем {amount}...");
                balance -= amount;
                Console.WriteLine($"Операция успешно выполнена! Остаток: {balance}");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств для снятия {amount}. Остаток: {balance}");
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(locker); 
            }
        }
    }
}