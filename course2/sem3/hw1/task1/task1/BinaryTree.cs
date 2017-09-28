using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    /// <summary>
    /// Class that describes binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        /// <summary>
        /// Root of the tree
        /// </summary>
        private static Node<T> root;
        /// <summary>
        /// Constructor without any arguments
        /// </summary>
        public BinaryTree()
        {
            root = null;
        }
        /// <summary>
        /// Constructor that recieve a generic type
        /// </summary>
        /// <param name="data"></param>
        public BinaryTree(T data)
        { 
            root = new Node<T>(data);
        }
        /// <summary>
        /// Method that shows all the tree nodes
        /// </summary>
        public void ConsoleShow()
        {
            if (root == null)
            {
                Console.WriteLine("empty tree");
            }
            ConsoleShow(root);

        }
        /// <summary>
        /// Method that add new nodes to tree
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (root == null)
            {
                root = new Node<T>(data);
            }
            else
            {
                Add(root, data);
            }
        }
        /// <summary>
        /// Method that finds node
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Find(T data)
        {
            return Find(root, data);
        }
        /// <summary>
        /// Overloaded public method that removes node from tree
        /// </summary>
        /// <param name="data"></param>
        public void Remove(T data)
        {
            if (root == null)
            {
                return;
            }
            if (root.Data.Equals(data))
            {
                RefreshNode(root);
                return;
            }
            Remove(root, data);
        }
        /// <summary>
        /// Private method that shows subtree
        /// </summary>
        /// <param name="node"></param>
        private void ConsoleShow(Node<T> node)
        {
            if (node != null)
            {
                ConsoleShow(node.Left);
                Console.WriteLine(node);
                ConsoleShow(node.Right);
            }
        }
        /// <summary>
        /// Private method that adds new node to subtree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        private void Add(Node<T> node, T data)
        {
            if (node.Data.Equals(data))
            {
                return;
            }
            if (data.CompareTo(node.Data) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(data);
                    node.Right.Parent = node;
                }
                else
                {
                    Add(node.Right, data);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(data);
                    node.Left.Parent = node;
                }
                else
                {
                    Add(node.Left, data);
                }
            }
        }
        /// <summary>
        /// Private method that finds node in subtree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool Find(Node<T> node, T data)
        {
            if (node == null)
            {
                return false;
            }
            if (node.Data.Equals(data))
            {
                return true;
            }
            if (data.CompareTo(node.Data) > 0)
            {
                return Find(node.Right, data);
            }
                return Find(node.Left, data);
            
        }
        /// <summary>
        /// Private method that remove node from subtree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        private void Remove(Node<T> node, T data)
        {
            if (data.CompareTo(node.Data) > 0)
            {
                if (node.Right == null)
                {
                    return;
                }
                if (node.Right.Data.Equals(data))
                {
                    RefreshNode(node.Right);
                    return;
                }
                Remove(node.Right, data);
            }
            else
            {
                if (node.Left == null)
                {
                    return;
                }
                if (node.Left.Data.Equals(data))
                {
                    RefreshNode(node.Left);
                    return;
                }
                Remove(node.Left, data);
            }
        }
        /// <summary>
        /// Private method that
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private void RefreshNode(Node<T> node)
        {
            Node<T> refresh = null;

            if (node.Right != null && node.Left != null)
            {
                refresh = node.Left;

                Node<T> temp = refresh;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
                temp.Right = node.Right;
                node.Right.Parent = temp;
            }
            else
            {
                refresh = node.Left != null ? node.Left : node.Right;
            }

            if (node.Parent == null)
            {
                root = refresh;
            }
            else
            {
                if (node.Parent.Left != null && node.Parent.Left.Equals(node))
                {
                    node.Parent.Left = refresh;
                }
                else
                {
                    node.Parent.Right = refresh;
                }
            }

            if (refresh != null)
            {
                refresh.Parent = node.Parent;
            }
        }

        /// <summary>
        /// IEnumerable intefrace realisation
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new BinaryTreeEnumerator();
        }

        /// <summary>
        /// IEnumerable interface realisation
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
