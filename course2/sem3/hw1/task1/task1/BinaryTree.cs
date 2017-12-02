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
    public partial class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        /// <summary>
        /// Root of the tree
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Constructor without any arguments
        /// </summary>
        public BinaryTree() { }

        /// <summary>
        /// Constructor that recieve a generic type
        /// </summary>
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
        public bool Find(T data) => Find(root, data);

        /// <summary>
        /// Overloaded public method that removes node from tree
        /// </summary>
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
        /// Says if there is an elemnt with key
        /// </summary>
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
        /// Remove node using key
        /// </summary>
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
        /// Refresh node
        /// </summary>
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
        public IEnumerator<T> GetEnumerator() => new BinaryTreeEnumerator(root);

        /// <summary>
        /// IEnumerable interface realisation
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class BinaryTreeEnumerator : IEnumerator<T>
        {

            public T Current => current.Data;

            private Node<T> current;
            private Node<T> root;

            private bool isFirst;

            object IEnumerator.Current
            {
                get { return current.Data; }
            }

            public BinaryTreeEnumerator(Node<T> root)
            {
                this.root = root;
                current = root;
                isFirst = true;

                while (current != null && current.Left != null)
                {
                    current = current.Left;
                }
            }

            public void Dispose()
            {
                this.root = null;
            }

            public bool MoveNext()
            {
                if (isFirst)
                {
                    isFirst = false;
                    return true;
                }
                if (current != null)
                {
                    current = GetNext();
                }

                return current != null;
            }

            public void Reset()
            {
                current = root;
                isFirst = true;

                while (current != null && current.Left != null)
                {
                    current = current.Left;
                }
            }

            private Node<T> GetNext()
            {
                if (current.Right != null)
                {
                    Node<T> tmp = current.Right;

                    while (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                    }

                    return tmp;
                }

                Node<T> temp = current;
                while (temp.Parent != null && temp.Parent.Right != null && temp.Parent.Right.Equals(temp))
                {
                    temp = temp.Parent;
                }

                return temp.Parent;
            }
        }
    }
}