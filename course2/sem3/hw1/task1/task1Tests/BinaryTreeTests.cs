using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task1;

namespace Task1Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        Random rand = new Random();

        [TestMethod]
        public void AddTest()
        {
            var tree = new BinaryTree<int>();
            var list = new List<int>();
            int temp;

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
            var tree = new BinaryTree<int>();
            Assert.IsFalse(tree.Find(rand.Next(1000)));
        }

        [TestMethod]
        public void AdvancedFindNothingTest()
        {
            int temp = rand.Next(1000);
            var tree = new BinaryTree<int>();
            Assert.IsFalse(tree.Find(rand.Next(1000)));
            tree.Add(temp);
            tree.Remove(temp);
            Assert.IsFalse(tree.Find(temp));
        }

        [TestMethod]
        public void RemoveTest()
        {
            var tree = new BinaryTree<int>();
            var list = new List<int>();
            int temp;

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
            var tree = new BinaryTree<int>();
            var list = new List<int>();
            int temp;

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
            var tree = new BinaryTree<int>();
            Assert.IsFalse(tree.Find(10));
            tree.Remove(10);
            Assert.IsFalse(tree.Find(10));
        }

        [TestMethod]
        public void IteratorTest()
        {
            var tree = new BinaryTree<int>();
            var values = new int[10];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = rand.Next(100);
            }

            for (int i = 0; i < values.Length; i++)
            {
                tree.Add(values[i]);
            }

            IEnumerator<int> iterator = tree.GetEnumerator();

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
            var tree = new BinaryTree<int>
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
