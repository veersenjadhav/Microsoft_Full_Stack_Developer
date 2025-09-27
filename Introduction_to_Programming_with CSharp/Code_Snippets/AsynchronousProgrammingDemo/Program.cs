using System.Reflection;

public class Program
{
    public async Task DownloadFile()
    {
        try
        {
            Console.WriteLine("File download started...");
            await Task.Delay(5000);
            Console.WriteLine("File download completed...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured: {ex}");
        }
    }

    public async Task DownloadFile2()
    {
        try
        {
            Console.WriteLine("File 2 download started...");
            await Task.Delay(15000);
            Console.WriteLine("File 2 download completed...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured: {ex}");
        }
    }

    public void TickCounter()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Tick Tick {i}");
            Thread.Sleep(2000);
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
