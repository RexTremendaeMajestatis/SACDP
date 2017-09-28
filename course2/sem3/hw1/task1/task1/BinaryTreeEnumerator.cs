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

            public T Current => current.Data;

            private Node<T> current;

            private bool isFirst;
            object IEnumerator.Current
            {
                get { return current.Data; }
            }

            public BinaryTreeEnumerator()
            {
                current = root;
                isFirst = true;

                while (current != null && current.Left != null)
                {
                    current = current.Left;
                }
            }

            public void Dispose()
            {

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
