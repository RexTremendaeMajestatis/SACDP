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
            List<string> a = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                a.Add("kek");
            }
            IEnumerator<string> b = a.GetEnumerator();
            for (int i = 0; i < 100; i++)
            {
                b.MoveNext();
            }
            Console.WriteLine(b.Current);
            Console.ReadKey();
        }
    }
}
