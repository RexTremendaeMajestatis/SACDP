namespace Task1
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            a.Add(2);
            a.Add(1);
            a.Add(3);

            
            Console.WriteLine(a.Find(2));
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