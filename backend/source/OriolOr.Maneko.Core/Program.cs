using OriolOr.Maneko.Services;

public class Program
{
    static void Main(string[] args)
    {
        DataInitializer dataInitializer = new DataInitializer();
        dataInitializer.Initialize();

        Console.WriteLine("Hello, World!");
    }
}

