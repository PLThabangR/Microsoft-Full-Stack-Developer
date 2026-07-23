public class Animal: IAnimal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a sound.");
    }
    public void sleep()
    {
        Console.WriteLine("The animal is sleeping.");
    }
}

public class Dog: Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("The dog barks.");
    }

    public void sleep()
    {
        Console.WriteLine("dog sleeps");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("The cat is making sound.");
    }

}


public interface IAnimal
{
     void sleep(); 
}