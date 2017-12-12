namespace Task1Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Task1;

    [TestClass]
    public class BinaryTreeTests
    {
        private int[] addArray = new int[10] { 3, 31, 1, 6, 4, 75, 12, 9, 23, 8 };
        private int someValue = 31415;

        [TestMethod]
        public void AddTest()
        {
            var tree = new BinaryTree<int>();
            var list = new List<int>();
 
            for (int i = 0; i < 10; i++)
            {
                tree.Add(addArray[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(tree.Find(addArray[i]));
            }

            Assert.IsFalse(tree.Find(1001));
        }

        [TestMethod]
        public void FindNothingTest()
        {
            var tree = new BinaryTree<int>();
            Assert.IsFalse(tree.Find(someValue));
        }

        [TestMethod]
        public void AdvancedFindNothingTest()
        {
            var tree = new BinaryTree<int>();
            Assert.IsFalse(tree.Find(someValue));
            tree.Add(someValue);
            tree.Remove(someValue);
            Assert.IsFalse(tree.Find(someValue));
        }

        [TestMethod]
        public void RemoveTest()
        {
            var tree = new BinaryTree<int>();

            for (int i = 0; i < 10; i++)
            {
                tree.Add(addArray[i]);
            }

            tree.Remove(addArray[5]);
            Assert.IsFalse(tree.Find(addArray[5]));
        }

        [TestMethod]
        public void AdvancedRemoveTest()
        {
            var tree = new BinaryTree<int>();

            for (int i = 0; i < 10; i++)
            {
                tree.Add(addArray[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                tree.Remove(addArray[i]);
                Assert.IsFalse(tree.Find(addArray[i]));
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
        public void RepeatedIteratorTest()
        {
            var tree = new BinaryTree<int>();
            int[] save = new int[10] { 20, 10, 51, 21, 34, 37, 21, 58, 51, 67 };

            for (int i = 0; i < 10; i++)
            {
                tree.Add(save[i]);
            }

            IEnumerator<int> iterator = tree.GetEnumerator();

            iterator.MoveNext();
            int buff = iterator.Current;

            for (int i = 0; i < tree.Size - 1; i++)
            {
                iterator.MoveNext();
                int temp = iterator.Current;

                Assert.IsTrue(buff <= temp);

                buff = temp;
            }
        }

        [TestMethod]
        public void TreeSizeTest()
        {
            var tree = new BinaryTree<int>
            {
                2,
                1,
                3
            };

            int expectedSize = 3;
            Assert.AreEqual(tree.Size, expectedSize);
        }

        [TestMethod]
        public void AdvancedTreeSizeTest()
        {
            var tree = new BinaryTree<int>
            {
                2,
                1,
                3
            };

            tree.Remove(2);
            tree.Add(10);

            int expectedSize = 3;
            Assert.AreEqual(tree.Size, expectedSize);
        }

        [TestMethod]
        public void IEnumenatorTest()
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
