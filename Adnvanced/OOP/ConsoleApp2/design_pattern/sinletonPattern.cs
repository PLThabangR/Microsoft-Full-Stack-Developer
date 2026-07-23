public class Database
{
    private static Database instance;
    private static   object lockObject = new object();

    // Private constructor prevents instantiation from other classes
    private Database() { }

    public static Database GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Database();
                }
            }
        }
        return instance;
    }

    public void Connect()
    {
        Console.WriteLine("Database connected.");
    }
}

public class Program
{
    public static void Main()
    {
        Database db1 = Database.GetInstance();
        Database db2 = Database.GetInstance();

        db1.Connect();
        Console.WriteLine(object.ReferenceEquals(db1, db2)); // Outputs: True
    }
    }