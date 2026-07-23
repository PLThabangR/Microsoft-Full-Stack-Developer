

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           // Program program = new Program();
            // await program.getData();
            await getData();
        
            Console.WriteLine("Operaation completed ");
        }




        public static async Task getData()
        {
            Console.WriteLine("Operaation started");
            await Task.Delay(5000);
            Console.WriteLine("Operaation completed after 5 seconds");


        }
    }
}