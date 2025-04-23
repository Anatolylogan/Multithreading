
class Program
{
    static void Main(string[] args)
    {
        ProgramBase printer = new ProgramBase();
        Thread thread = new Thread(printer.PrintNumbers);
        thread.Start();

        Console.WriteLine("Основной поток завершён.");
        Console.ReadLine(); 
    }
}
