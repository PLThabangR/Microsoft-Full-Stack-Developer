using System;
namespace spa
 {   
public class Spa : Pool

{
    public int heatLevel;
    public Spa(int chlorine, int water, int heat): base(chlorine, water)
    {
        heatLevel = heat;
    }
    public void SpaInfo()
    {
        Console.WriteLine($"Spa: {chlorineLevel}, {waterLevel}, {heatLevel}");
    }
}}