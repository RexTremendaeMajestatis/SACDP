using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomRandom randomizer = new CustomRandom();
            Network a = new Network(@"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\parallel.txt", randomizer);
            Console.WriteLine(a.StartGame());
            Console.ReadKey();
        }
    }
}
