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

        for (int i = 0; i < tasks.Count; i++)
        {
            try
            {
                int length = await tasks[i];
                Console.WriteLine($"{urls[i]}: длина = {length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{urls[i]}: ошибка - {ex.Message}");
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

