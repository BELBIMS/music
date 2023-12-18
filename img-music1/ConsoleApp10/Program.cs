using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        HttpClient client = new();   // Создаем экземпляр класса HttpClient для выполнения HTTP-запросов

        Console.WriteLine("Введите ссылку для скачивания картинки: ");
        string nameWebsite = Console.ReadLine();       // Запрашиваем у пользователя ссылку для скачивания картинки

        HttpResponseMessage response = await client.GetAsync(nameWebsite);        // Выполняем асинхронный HTTP-запрос и получаем ответ
        byte[] data = await response.Content.ReadAsByteArrayAsync();          // Считываем данные из ответа в байтовый массив

        Console.WriteLine("Введите путь сохранения: ");
        string link = Console.ReadLine();              // Запрашиваем путь для сохранения картинки
        await File.WriteAllBytesAsync(link, data);               // Асинхронно записываем данные в файл по указанному пути

        Process.Start(new ProcessStartInfo { FileName = link, UseShellExecute = true });       // Открываем сохраненный файл с помощью процесса

        HttpClient client1 = new HttpClient();              // Создаем новый экземпляр класса HttpClient для выполнения второго HTTP-запроса

        Console.WriteLine("Введите ссылку для скачивания песни: ");         // Запрашиваем у пользователя ссылку для скачивания песни
        string nameWebsite1 = Console.ReadLine();

 
        HttpResponseMessage response1 = await client1.GetAsync(nameWebsite1);         // Выполняем второй HTTP-запрос и получаем ответ
        byte[] data1 = response1.Content.ReadAsByteArrayAsync().Result;          // Считываем данные из ответа в байтовый массив

        Console.WriteLine("Введите путь сохранения: ");        // Запрашиваем путь для сохранения песни
        string link1 = Console.ReadLine(); 
        File.WriteAllBytes(link1, data1);          // Записываем данные в файл по указанному пути

        Process.Start(new ProcessStartInfo { FileName = link1, UseShellExecute = true });        // Открываем сохраненный файл с помощью процесса
    }
}
