using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using task1;

namespace Task1Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void AddTest()
        {
            var tree = new BinaryTree<Int32>();
            var list = new List<Int32>();
            Random rand = new Random();
            Int32 temp;

            for (int i = 0; i < 10; i++)
            {
                temp = rand.Next(1000);
                tree.Add(temp);
                list.Add(temp);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(tree.Find(list[i]));
            }

            Assert.IsFalse(tree.Find(1001));

        }

        [TestMethod]
        public void FindNothingTest()
        {
            Random rand = new Random();
            var tree = new BinaryTree<Int32>();
            Assert.IsFalse(tree.Find(rand.Next(1000)));
        }

    

        [TestMethod]
        public void AdvancedFindNothingTest()
        {
            Random rand = new Random();
            Int32 temp = rand.Next(1000);
            var tree = new BinaryTree<Int32>();
            Assert.IsFalse(tree.Find(rand.Next(1000)));
            tree.Add(temp);
            tree.Remove(temp);
            Assert.IsFalse(tree.Find(temp));
        }

        [TestMethod]
        public void RemoveTest()
        {
            var tree = new BinaryTree<Int32>();
            var list = new List<Int32>();
            Random rand = new Random();
            Int32 temp;

            for (int i = 0; i < 10; i++)
            {
                temp = rand.Next(100);
                tree.Add(temp);
                list.Add(temp);
            }

            tree.Remove(list[5]);
            Assert.IsFalse(tree.Find(list[5]));
        }

        [TestMethod]
        public void AdvancedRemoveTest()
        {
            var tree = new BinaryTree<Int32>();
            var list = new List<Int32>();
            Random rand = new Random();
            Int32 temp;

            for (int i = 0; i < 10; i++)
            {
                temp = rand.Next(1000);
                tree.Add(temp);
                list.Add(temp);
            }

            for (int i = 0; i < 10; i++)
            {
                tree.Remove(list[i]);
                Assert.IsFalse(tree.Find(list[i]));
            }
        }

        [TestMethod]
        public void RemoveFromEmptyTest()
        {
            var tree = new BinaryTree<Int32>();
            Assert.IsFalse(tree.Find(10));
            tree.Remove(10);
            Assert.IsFalse(tree.Find(10));
        }

        [TestMethod]
        public void IteratorTest()
        {
            var tree = new BinaryTree<Int32>();
            Int32[] values = new Int32[10];

            Random rand = new Random();

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = rand.Next(100);
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
            var tree = new BinaryTree<Int32>
            {
                2,
                1,
                3
            };

            int i = 0;
            foreach (var value in tree)
            {
                Console.WriteLine(value);
                i++;
            }

            Assert.AreEqual(3, i);
        }

    }
}
