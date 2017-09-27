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
        /// <summary>
        /// Node that contains data & references to another nodes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Node<T>
        {
            /// <summary>
            /// Contains info
            /// </summary>
            public T Data { get; }
            /// <summary>
            /// Reference to left node
            /// </summary>
            public Node<T> Left { get; set; }
            /// <summary>
            /// Reference to right node
            /// </summary>
            public Node<T> Right { get; set; }
            /// <summary>
            /// Reference to parent
            /// </summary>
            public Node<T> Parent { get; set; }
            /// <summary>
            /// Constructor that recieve generic type
            /// </summary>
            /// <param name="data"></param>
            public Node(T data)
            {
                this.Data = data;
                this.Left = null;
                this.Right = null;
            }
            /// <summary>
            /// Method that allows turn node into string
            /// </summary>
            /// <returns></returns>
            public override string ToString() => "(" + this.GetType() + ";" + Data.ToString() + ")";
        }
    }
}
