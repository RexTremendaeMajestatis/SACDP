using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2;

namespace NetworkTest
{
    public class TestRandom : ICustomRandom
    {
        int ICustomRandom.Random()
        {
            return 0;
        }
    }

    [TestClass]
    public class NetworkTests
    {
        private string consequencePath = @"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\consequence.txt";
        private string parallelPath = @"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\parallel.txt";
        private string path = @"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\input.txt";
        TestRandom tr = new TestRandom();

        /// <summary>
        /// Try to initialize network class
        /// </summary>
        [TestMethod]
        public void CreationTest()
        {
            Network network = new Network(path, tr);
        }

        /// <summary>
        /// Try to infect sequence of computers with 100% chance
        /// </summary>
        [TestMethod]
        public void SequenceTest()
        {
            generateComputerSequence();
            Network network = new Network(consequencePath, tr);
        }

        private void generateComputerSequence()
        {
            using (StreamWriter sw = new StreamWriter(consequencePath, false))
            {
                sw.WriteLine(3);
                sw.WriteLine("Windows");
                sw.WriteLine("MacOs");
                sw.WriteLine("Linux");
                sw.WriteLine();
                sw.WriteLine("1");
                sw.WriteLine();
                sw.WriteLine("2");
                sw.WriteLine("1 2");
                sw.WriteLine("2 3");
            }
        }
        
    }
}
