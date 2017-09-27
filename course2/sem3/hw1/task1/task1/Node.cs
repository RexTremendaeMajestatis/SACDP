using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public partial class BinaryTree<T>
        where T : IComparable
    {
        public class Node<T>
        {
            public T data { get; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public Node<T> Parent { get; set; }
            public Node(T data)
            {
                this.data = data;
                this.Left = null;
                this.Right = null;
            }
        }
    }
}
