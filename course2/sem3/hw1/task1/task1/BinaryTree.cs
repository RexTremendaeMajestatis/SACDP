using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Binary tree class
    /// </summary>
    /// <typeparam name="T">Any type that implements IComparable</typeparam>
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        /// <summary>
        /// Root of the tree
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class
        /// </summary>>
        public BinaryTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class
        /// </summary>
        /// <param name="data">Data of root</param>
        public BinaryTree(T data) => this.root = new Node<T>(data);

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
        /// Add new nodes
        /// </summary>
        /// <param name="data">A data to add</param>
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
        /// Find node in tree
        /// </summary>
        /// <param name="data">A data to find</param>
        /// <returns>True if tree contains node</returns>
        public bool Find(T data) => Find(root, data);

        /// <summary>
        /// Remove a node from tree
        /// </summary>
        /// <param name="data">A data to remove</param>
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
        /// Get IEnumerator
        /// </summary>
        /// <returns>BinaryTreeEminerator</returns>
        public IEnumerator<T> GetEnumerator() => new BinaryTreeEnumerator(root);

        /// <summary>
        /// IEnumerable interface 
        /// </summary>
        /// <returns>BinaryTreeEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ConsoleShow(Node<T> node)
        {
            if (node != null)
            {
                ConsoleShow(node.Left);
                Console.WriteLine(node);
                ConsoleShow(node.Right);
            }
        }

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

        private class BinaryTreeEnumerator : IEnumerator<T>
        {
            private Node<T> current;
            private Node<T> root;

            private bool isFirst;

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

            public T Current => current.Data;

            object IEnumerator.Current
            {
                get { return current.Data; }
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

        private class Node<T>
        {
            public Node(T data)
            {
                this.Data = data;
                this.Left = null;
                this.Right = null;
            }

            public T Data { get; }

            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }

            public Node<T> Parent { get; set; }

            public override string ToString() => "(" + this.GetType() + ";" + Data.ToString() + ")";
        }
    }
}