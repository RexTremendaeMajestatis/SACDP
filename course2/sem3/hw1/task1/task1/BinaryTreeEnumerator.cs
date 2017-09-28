using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public partial class BinaryTree<T>
    {

        private class BinaryTreeEnumerator : IEnumerator<T>
        {

            public T Current
            {
                get { return current.Data; }
            }

            private Node<T> current;
            private Node<T> next;
            object IEnumerator.Current
            {
                get { return current.Data; }
            }

            public BinaryTreeEnumerator()
            {
                current = null;
                next = root;

                while (next != null && next.Left != null)
                {
                    next = next.Left;
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                Node<T> next = GetNext();

                if (next != null)
                {
                    current = next;
                }

                return next != null;
            }

            public void Reset()
            {
                current = root;

                while (current.Left != null)
                {
                    current = current.Left;
                }
            }

            private Node<T> GetNext()
            {
                if (current.Right != null)
                {
                    Node<T> tmp = current.Right;

                    while (tmp.Right != null)
                    {
                        tmp = tmp.Right;
                    }

                    return tmp;
                }

                Node<T> temp = current;
                while (temp.Parent != null && temp.Parent.Right.Equals(temp))
                {
                    temp = temp.Parent;
                }

                return temp.Parent;
            }
        }
        
    }
}
