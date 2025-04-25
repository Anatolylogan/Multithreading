public class BankAccount
{
    private object lockObj = new object();

    public int Balance { get; private set; }

    public BankAccount(int initialBalance)
    {
        Balance = initialBalance;
    }

    public void Withdraw(int amount)
    {
        lock (lockObj) 
        {
            Console.WriteLine($"Пользователь пытается снять {amount} . Текущий баланс: {Balance}");

            if (Balance >= amount)
            {
                Thread.Sleep(100);
                Balance -= amount;
                Console.WriteLine($"Успешно снято: {amount}. Остаток: {Balance}");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств для снятия {amount}. Остаток: {Balance}");
            }
        }
    }
}