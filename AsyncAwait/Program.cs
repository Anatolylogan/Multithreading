class Program
{
    static async Task Main()
    {
        List<string> urls = new List<string>
        {
            "https://www.microsoft.com",
            "https://www.google.com"
        };

        List<Task<int>> tasks = new List<Task<int>>();

        foreach (var url in urls)
        {
            tasks.Add(GetPageLengthAsync(url));
        }

        int[] results = await Task.WhenAll(tasks);

        for (int i = 0; i < urls.Count; i++)
        {
            Console.WriteLine($"Сайт: {urls[i]}, длина HTML: {results[i]} символов");
        }

        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine();
    }

    static async Task<int> GetPageLengthAsync(string url)
    {
        using HttpClient client = new HttpClient();
        string html = await client.GetStringAsync(url);
        return html.Length;
    }
}
