class Program
{
    static async Task Main()
    {
        List<string> urls = new List<string>
        {
            "https://www.microsoft.com",
            "https://www.google.com"
        };

        List<Task<(string url, int length)>> tasks = new List<Task<(string, int)>>();

        foreach (var url in urls)
        {
            tasks.Add(GetPageLengthAsync(url));
        }

        Task<(string url, int length)> firstFinished = await Task.WhenAny(tasks);

        var fastestResult = await firstFinished;
        Console.WriteLine($"Самая быстрая страница: {fastestResult.url}, длина HTML: {fastestResult.length}");

        var allResults = await Task.WhenAll(tasks);

        Console.WriteLine("Результаты всех запросов:");
        foreach (var result in allResults)
        {
            Console.WriteLine($"Сайт: {result.url}, длина HTML: {result.length}");
        }

        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine();
    }

    static async Task<(string url, int length)> GetPageLengthAsync(string url)
    {
        using HttpClient client = new HttpClient();
        string html = await client.GetStringAsync(url);
        return (url, html.Length);
    }
}
