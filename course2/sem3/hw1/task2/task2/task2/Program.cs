using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomRandom randomizer = new CustomRandom();
            Network a = new Network(@"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\input.txt", randomizer);
            Console.WriteLine(a.Game());
            Console.ReadKey();
        }
    }
}
