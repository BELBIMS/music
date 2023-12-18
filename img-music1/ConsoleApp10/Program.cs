using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        HttpClient client = new();

        Console.WriteLine("Введите ссылку для скачивания картинки: ");
        string nameWebsite = Console.ReadLine();

        HttpResponseMessage response = await client.GetAsync(nameWebsite);
        byte[] data = await response.Content.ReadAsByteArrayAsync();

        Console.WriteLine("Введите путь сохранения: ");
        string link = Console.ReadLine();
        await File.WriteAllBytesAsync(link, data);

        Process.Start(new ProcessStartInfo { FileName = link, UseShellExecute = true });

        HttpClient client1 = new HttpClient();

        Console.WriteLine("Введите ссылку для скачивания песни: ");
        string nameWebsite1 = Console.ReadLine();


        HttpResponseMessage response1 = await client1.GetAsync(nameWebsite1);
        byte[] data1 = response1.Content.ReadAsByteArrayAsync().Result;

        Console.WriteLine("Введите путь сохранения: ");
        string link1 = Console.ReadLine();
        File.WriteAllBytes(link1, data1);

        Process.Start(new ProcessStartInfo { FileName = link1, UseShellExecute = true });
    }
}