public class Pool
{
    public int chlorineLevel;
    public int waterLevel;
    public Pool(int chlorine, int water)
    {
        chlorineLevel = chlorine;
        waterLevel = water;
    }
    public void PoolInfo()
    {
        Console.WriteLine($"Pool: {chlorineLevel}, {waterLevel}");
    }
}