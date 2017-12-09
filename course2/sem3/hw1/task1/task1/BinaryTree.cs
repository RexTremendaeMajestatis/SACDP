namespace Task1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Binary tree class
    /// </summary>
    /// <typeparam name="T">Type of value in a tree nodes</typeparam>
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        /// <summary>
        /// Root of the tree
        /// </summary>
        private Node<T> root;

        private int size;

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
        /// Amount of tree elements
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        /// Method that shows all the tree nodes
        /// </summary>
        public void ConsoleShow()
        {
            if (this.root == null)
            {
                Console.WriteLine("empty tree");
            }

            this.ConsoleShow(this.root);
        }

        /// <summary>
        /// Add new nodes
        /// </summary>
        /// <param name="data">A data to add</param>
        public void Add(T data)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(data);
                this.size++;
            }
            else
            {
                this.Add(this.root, data);
            }
        }

        /// <summary>
        /// Find node in tree
        /// </summary>
        /// <param name="data">A data to find</param>
        /// <returns>True if tree contains node</returns>
        public bool Find(T data) => this.Find(this.root, data);

        /// <summary>
        /// Remove a node from tree
        /// </summary>
        /// <param name="data">A data to remove</param>
        public void Remove(T data)
        {
            if (this.root == null)
            {
                return;
            }

            if (this.root.Data.Equals(data))
            {
                this.RefreshNode(this.root);
                this.size--;
                return;
            }

            this.Remove(this.root, data);
        }

        /// <summary>
        /// Get IEnumerator object that allows walking the tree
        /// </summary>
        /// <returns>BinaryTreeEminerator</returns>
        public IEnumerator<T> GetEnumerator() => new BinaryTreeEnumerator(this.root);

        /// <summary>
        /// IEnumerable interface 
        /// </summary>
        /// <returns>BinaryTreeEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ConsoleShow(Node<T> node)
        {
            if (node != null)
            {
                this.ConsoleShow(node.Left);
                Console.WriteLine(node);
                this.ConsoleShow(node.Right);
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
                    this.size++;
                }
                else
                {
                    this.Add(node.Right, data);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(data);
                    node.Left.Parent = node;
                    this.size++;
                }
                else
                {
                    this.Add(node.Left, data);
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
                return this.Find(node.Right, data);
            }

            return this.Find(node.Left, data);
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
                    this.RefreshNode(node.Right);
                    this.size--;
                    return;
                }

                this.Remove(node.Right, data);
            }
            else
            {
                if (node.Left == null)
                {
                    return;
                }

                if (node.Left.Data.Equals(data))
                {
                    this.RefreshNode(node.Left);
                    this.size--;
                    return;
                }

                this.Remove(node.Left, data);
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
                this.root = refresh;
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
                this.current = root;
                this.isFirst = true;

                while (this.current != null && this.current.Left != null)
                {
                    this.current = this.current.Left;
                }
            }

            public T Current { get => this.current.Data; }

            object IEnumerator.Current
            {
                get { return this.current.Data; }
            }

            public void Dispose()
            {
                this.root = null;
            }

            public bool MoveNext()
            {
                if (this.isFirst)
                {
                    this.isFirst = false;
                    return true;
                }

                if (this.current != null)
                {
                    this.current = this.GetNext();
                }

                return this.current != null;
            }

            public void Reset()
            {
                this.current = this.root;
                this.isFirst = true;

                while (this.current != null && this.current.Left != null)
                {
                    this.current = this.current.Left;
                }
            }

            private Node<T> GetNext()
            {
                if (this.current.Right != null)
                {
                    Node<T> tmp = this.current.Right;

                    while (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                    }

                    return tmp;
                }

                Node<T> temp = this.current;
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

            public override string ToString() => "(" + this.GetType() + ";" + this.Data.ToString() + ")";
        }
    }
}