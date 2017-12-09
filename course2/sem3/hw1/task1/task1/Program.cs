namespace Task1
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            int[] save = new int[10] { 20, 10, 51, 21, 34, 37, 21, 58, 51, 67 };

            for (int i = 0; i < 10; i++)
            {
                tree.Add(save[i]);
            }

            foreach (var a in tree)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }
    }
}