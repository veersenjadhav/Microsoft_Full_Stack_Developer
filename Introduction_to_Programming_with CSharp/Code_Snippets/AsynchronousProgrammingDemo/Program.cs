using System.Reflection;

public class Program
{
    public async Task DownloadFile()
    {
        Console.WriteLine("File download started...");
        await Task.Delay(5000);
        Console.WriteLine("File download completed...");
    }

    public async Task DownloadFile2()
    {
        Console.WriteLine("File2 download started...");
        await Task.Delay(15000);
        Console.WriteLine("File2 download completed...");
    }

    public void TickCounter()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Tick Tick {i}");
            Thread.Sleep(1000);
        }
    }

    public static async Task Main(string[] args)
    {
        Program lobjProg = new Program();

        Task task1 = lobjProg.DownloadFile();
        Task task2  = lobjProg.DownloadFile2();
        lobjProg.TickCounter();

        await Task.WhenAll(task1, task2);
    }
}
