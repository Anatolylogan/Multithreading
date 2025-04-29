class Program
{
    static async Task Main()
    {
        List<string> urls = new List<string>
        {
            "https://microsoft.com",
            "https://this-url-does-not-exist.fake", 
            "https://www.google.com"
        };

        List<Task<(string url, int length, Exception error)>> tasks = new();

        foreach (var url in urls)
        {
            tasks.Add(GetPageLengthSafeAsync(url));
        }

        var results = await Task.WhenAll(tasks);

        Console.WriteLine("Результаты:");
        foreach (var result in results)
        {
            if (result.error == null)
            {
                Console.WriteLine($"Успех: {result.url}, длина: {result.length}");
            }
            else
            {
                Console.WriteLine($"Ошибка при доступе к {result.url}: {result.error.Message}");
            }
        }

        Console.WriteLine("Готово. Нажмите Enter для выхода.");
        Console.ReadLine();
    }
    static async Task<(string url, int length, Exception error)> GetPageLengthSafeAsync(string url)
    {
        try
        {
            using HttpClient client = new();
            string html = await client.GetStringAsync(url);
            return (url, html.Length, null);
        }
        catch (Exception ex)
        {
            return (url, 0, ex);
        }
    }
}

