using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using task1;

namespace task1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            List<Int32> b = new List<Int32>();
            Random c = new Random();
            Int32 d;

            for (int i = 0; i < 10; i++)
            {
                d = c.Next(1000);
                a.Add(d);
                b.Add(d);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(a.Find(b[i]));
            }

            Assert.IsFalse(a.Find(1001));

        }

        [TestMethod]
        public void FindNothingTest()
        {
            Random c = new Random();
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            Assert.IsFalse(a.Find(c.Next(1000)));
        }

    

        [TestMethod]
        public void AdvancedFindNothingTest()
        {
            Random c = new Random();
            Int32 d = c.Next(1000);
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            Assert.IsFalse(a.Find(c.Next(1000)));
            a.Add(d);
            a.Remove(d);
            Assert.IsFalse(a.Find(d));
        }

        [TestMethod]
        public void RemoveTest()
        {
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            List<Int32> b = new List<Int32>();
            Random c = new Random();
            Int32 d;

            for (int i = 0; i < 10; i++)
            {
                d = c.Next(100);
                a.Add(d);
                b.Add(d);
            }

            a.Remove(b[5]);
            Assert.IsFalse(a.Find(b[5]));
        }

        [TestMethod]
        public void AdvancedRemoveTest()
        {
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            List<Int32> b = new List<Int32>();
            Random c = new Random();
            Int32 d;

            for (int i = 0; i < 10; i++)
            {
                d = c.Next(1000);
                a.Add(d);
                b.Add(d);
            }

            for (int i = 0; i < 10; i++)
            {
                a.Remove(b[i]);
                Assert.IsFalse(a.Find(b[i]));
            }
        }

        [TestMethod]
        public void RemoveFromEmptyTest()
        {
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            Assert.IsFalse(a.Find(10));
            a.Remove(10);
            Assert.IsFalse(a.Find(10));
        }

        [TestMethod]
        public void IteratorTest()
        {
            BinaryTree<Int32> tree = new BinaryTree<Int32>();
            Int32[] values = new Int32[10];

            Random c = new Random();

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = c.Next(100);
            }

            for (int i = 0; i < values.Length; i++)
            {
                tree.Add(values[i]);
            }

            IEnumerator<Int32> iterator = tree.GetEnumerator();

            int buff = iterator.Current;
            for (int i = 0; i < values.Length - 1; i++)
            {
                iterator.MoveNext();
                int temp = iterator.Current;

                Assert.IsTrue(buff <= temp);

                buff = temp;
            }
        }

        [TestMethod]
        public void IenumenatorTest()
        {
            BinaryTree<Int32> a = new BinaryTree<Int32>();
            a.Add(2);
            a.Add(1);
            a.Add(3);
            int i = 0;
            foreach (var value in a)
            {
                Console.WriteLine(value);
                i++;
            }

            Assert.AreEqual(3, i);
        }

    }
}
