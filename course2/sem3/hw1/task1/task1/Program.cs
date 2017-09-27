using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<Int32> a = new BinaryTree<Int32>(2);
            a.Add(3);
            a.Add(1);
            a.Remove(2);
            a.ConsoleShow();
            Console.ReadKey();
        }
    }
}
