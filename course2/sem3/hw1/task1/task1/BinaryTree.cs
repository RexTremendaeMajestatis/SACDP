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
        void Add(Node<T> node, T data)
        {
            if (node.data.Equals(data))
            {
                return;
            }
            if (node.data.CompareTo(data) > 0)
            {
                if (node.right == null)
                {
                    node.right = new Node<T>(data);
                }
                else
                {
                    Add(node.right, data);
                }
            }
            else
            {
                if (node.left == null)
                {
                    node.left = new Node<T>(data);
                }
                else
                {
                    Add(node.left, data);
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
                return Find(node.right, data);
            }
                return Find(node.left, data);
            
        }
    }
}
