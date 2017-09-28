using System;
using System.Collections;
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
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            a.Add(2);
            a.Add(1);
            a.Add(3);
            int i = 0;
            foreach (var value in a)
            {
                Console.WriteLine(value);
                i++;
            }
            Console.ReadKey();
        }
    }
}
