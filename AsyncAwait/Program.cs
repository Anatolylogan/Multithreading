class Program
{
    static async Task Main()
    {
        List<string> urls = new()
        {
            "https://microsoft.com",
            "https://this-url-does-not-exist.fake",
            "https://www.google.com"
        };

        List<Task<int>> tasks = new();
        foreach (var url in urls)
        {
            tasks.Add(GetPageLengthAsync(url));
        }

        try
        {
            int[] lengths = await Task.WhenAll(tasks);

            for (int i = 0; i < urls.Count; i++)
            {
                Console.WriteLine($"{urls[i]}: длина = {lengths[i]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при загрузке страниц: {ex.Message}");

            if (ex is AggregateException aggEx)
            {
                foreach (var inner in aggEx.InnerExceptions)
                {
                    Console.WriteLine($"   ▶ {inner.GetType().Name}: {inner.Message}");
                }
            }
        }

        Console.WriteLine("Завершено. Нажмите Enter.");
        Console.ReadLine();
    }
    static async Task<int> GetPageLengthAsync(string url)
    {
        using HttpClient client = new();
        string html = await client.GetStringAsync(url); 
        return html.Length;
    }
}

