using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void GenerateFile()
        {
            using (StreamWriter sw = new StreamWriter("input.txt", false))
            {
                sw.WriteLine(3);
                sw.WriteLine("Windows");
                sw.WriteLine("MacOs");
                sw.WriteLine("Linux");
                sw.WriteLine();
                sw.WriteLine("1");
                sw.WriteLine();
                sw.WriteLine("2");
                sw.WriteLine("1 2");
                sw.WriteLine("2 3");
            }
        }
        static void Main(string[] args)
        {
            ICustomRandom randomizer = new CustomRandom();
            GenerateFile();
            Network a = new Network("input.txt", randomizer);
            Console.WriteLine(a.StartGame());
            Console.ReadKey();
        }
    }
}
