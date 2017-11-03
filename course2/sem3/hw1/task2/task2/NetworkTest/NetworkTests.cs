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
        private const string consequencePath = @"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\consequence.txt";
        private const string parallelPath = @"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\parallel.txt";
        private const string path = @"C:\Users\pavel\Documents\SPbSU\course2\sem3\hw1\task2\task2\input.txt";
        private TestRandom _tr = new TestRandom();

        /// <summary>
        /// Try to initialize network class
        /// </summary>
        [TestMethod]
        public void CreationTest()
        {
            Network network = new Network(path, _tr);
        }

        /// <summary>
        /// Try to infect a sequence of 3 computers with 100% chance
        /// </summary>
        [TestMethod]
        public void SequenceTest()
        {
            GenerateComputerSequence();
            Network network = new Network(consequencePath, _tr);

            string[] state = network.State().Split('\n');
            Assert.IsTrue(IsInfected(state[0]) 
                && !IsInfected(state[1]) 
                && !IsInfected(state[2]));

            network.Game();
            state = network.State().Split('\n');
            Assert.IsTrue(IsInfected(state[0]) 
                && IsInfected(state[1]) 
                && IsInfected(state[2]));
        }

        /// <summary>
        /// Try to infect a sequence of 3 computers with 100% chance manually
        /// </summary>
        [TestMethod]
        public void DetailSequenceTest()
        {
            GenerateComputerSequence();
            Network network = new Network(consequencePath, _tr);
            string[] state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0]) 
                && !IsInfected(state[1]) 
                && !IsInfected(state[2]));

            network.OneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0]) 
                && IsInfected(state[1]) 
                && !IsInfected(state[2]));

            network.OneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0]) 
                && IsInfected(state[1])
                && IsInfected(state[2]));
        }

        /// <summary>
        /// Try to infect parallel computers with 100% chance
        /// </summary>
        [TestMethod]
        public void ParallelTest()
        {
            GenerateComputerParallel();
            Network network = new Network(parallelPath, _tr);
            string[] state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                && !IsInfected(state[1])
                && !IsInfected(state[2])
                && !IsInfected(state[3])
                && !IsInfected(state[4])
                && !IsInfected(state[5])
                && !IsInfected(state[6]));

            network.Game();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])         
                && IsInfected(state[1])
                && IsInfected(state[2])
                && IsInfected(state[3])
                && IsInfected(state[4])
                && IsInfected(state[5])
                && IsInfected(state[6]));
        }

        [TestMethod]
        public void DetailParralelTest()
        {
            GenerateComputerParallel();
            Network network = new Network(parallelPath, _tr);
            string[] state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                          && !IsInfected(state[1])
                          && !IsInfected(state[2])
                          && !IsInfected(state[3])
                          && !IsInfected(state[4])
                          && !IsInfected(state[5])
                          && !IsInfected(state[6]));

            network.OneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                          && IsInfected(state[1])
                          && IsInfected(state[2])
                          && IsInfected(state[3])
                          && !IsInfected(state[4])
                          && !IsInfected(state[5])
                          && !IsInfected(state[6]));

            network.OneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                          && IsInfected(state[1])
                          && IsInfected(state[2])
                          && IsInfected(state[3])
                          && IsInfected(state[4])
                          && IsInfected(state[5])
                          && IsInfected(state[6]));
        }
        private void GenerateComputerSequence()
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

        private void GenerateComputerParallel()
        {
            using (StreamWriter sw = new StreamWriter(parallelPath, false))
            {
                sw.WriteLine("7");
                sw.WriteLine("Windows");
                sw.WriteLine("MacOs");
                sw.WriteLine("Linux");
                sw.WriteLine("Linux");
                sw.WriteLine("MacOs");
                sw.WriteLine("MacOs");
                sw.WriteLine("Linux");
                sw.WriteLine();
                sw.WriteLine("1");
                sw.WriteLine();
                sw.WriteLine("6");
                sw.WriteLine("1 2");
                sw.WriteLine("1 3");
                sw.WriteLine("1 4");
                sw.WriteLine("2 5");
                sw.WriteLine("3 6");
                sw.WriteLine("4 7");
            }
        }

        /// <summary>
        /// Returns true if computer is infected
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private bool IsInfected(string config)
        {
            //In case of infected computer the length of string is more than 9
            int length = config.Length;
            if (length > 11)
            {
                return true;
            }
            return false;
        }


        
    }
}
