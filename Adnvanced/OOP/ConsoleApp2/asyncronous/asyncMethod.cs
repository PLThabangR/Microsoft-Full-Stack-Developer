

public static void Main(string[] args)
{
    // Calling the asynchronous method
    Task.Run(async () => await PerformLongOperationAsync()).Wait();
    Console.WriteLine("Main method completed.");
}


public class Program
{
    public static async Task PerformLongOperationAsync()
    {
        Console.WriteLine("Operation started...");
        await Task.Delay(3000); // Simulate a delay of 3 seconds
        Console.WriteLine("Operation completed.");
    }
}