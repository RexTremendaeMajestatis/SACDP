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
        private Node<T> root;
        
        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(T data)
        { 
            root = new Node<T>(data);
        }
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
        public Node<T> Find(T data)
        {
            return Find(root, data);
        }
        public void Remove(T data)
        {
            if (root == null)
            {
                return;
            }
            if (root.data.Equals(data))
            {
                root = refreshNode(root);
                return;
            }
            Remove(root, data);
        }
        void Add(Node<T> node, T data)
        {
            if (node.data.Equals(data))
            {
                return;
            }
            if (node.data.CompareTo(data) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(data);
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
                }
                else
                {
                    Add(node.Left, data);
                }
            }
        }
        Node<T> Find(Node<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }
            if (node.data.Equals(data))
            {
                return node;
            }
            if (node.data.CompareTo(data) > 0)
            {
                return Find(node.Right, data);
            }
                return Find(node.Left, data);
            
        }
        void Remove(Node<T> node, T data)
        {
            if (node.data.CompareTo(data) > 0)
            {
                if (node.Right == null)
                {
                    return;
                }
                if (node.Right.data.Equals(data))
                {
                    node.Right = refreshNode(node.Right);
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
                if (node.Left.data.Equals(data))
                {
                    node.Left = refreshNode(node.Left);
                    return;
                }
                Remove(node.Left, data);
            }
        }
        Node<T> refreshNode(Node<T> node)
        {
            if (node.Right != null && node.Left != null)
            {
                Node<T> temp = node.Right;

                while (temp.Left != null)
                {
                    temp = temp.Left;
                }

                temp.Left = node.Left;
                return node.Right;
            }
            return node.Left != null ? node.Left : node.Right;
        }
    }
}
