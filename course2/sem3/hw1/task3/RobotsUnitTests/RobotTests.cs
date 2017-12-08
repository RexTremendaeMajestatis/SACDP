namespace RobotsUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task3;
    using System.IO;

    [TestClass]
    public class RobotTests
    {
        private const string TrueStatePath = "TrueState.txt";
        private const string FalseStatePath = "FalseState.txt";
        private const string AdvancedTrueStatePath = "AdvancedTrueState.txt";
        private RobotGraph robots;

        [TestMethod]
        public void TrueTest()
        {
            GenerateTrueFile();
            robots = new RobotGraph(TrueStatePath);
            Assert.IsTrue(robots.CheckCrash());
        }
        
        [TestMethod]
        public void FalseTest()
        {
            GenerateFalseFile();
            robots = new RobotGraph(FalseStatePath);
            Assert.IsFalse(robots.CheckCrash());
        }

        [TestMethod]
        public void AdvancedTrueTest()
        {
            GenerateAdvancedTrueFile();
            robots = new RobotGraph(AdvancedTrueStatePath);
            Assert.IsTrue(robots.CheckCrash());
        }

        private void GenerateTrueFile()
        {
            using (var sw = new StreamWriter(TrueStatePath, false))
            {
                sw.WriteLine(4);
                sw.WriteLine();
                sw.WriteLine(2);
                sw.WriteLine();
                sw.WriteLine(1);
                sw.WriteLine(3);
                sw.WriteLine();
                sw.WriteLine(3);
                sw.WriteLine();
                sw.WriteLine("2 1");
                sw.WriteLine("2 3");
                sw.WriteLine("2 4");
            }
        }

        private void GenerateFalseFile()
        {
            using (var sw = new StreamWriter(FalseStatePath, false))
            {
                sw.WriteLine(4);
                sw.WriteLine();
                sw.WriteLine(2);
                sw.WriteLine();
                sw.WriteLine(2);
                sw.WriteLine(3);
                sw.WriteLine();
                sw.WriteLine(4);
                sw.WriteLine();
                sw.WriteLine("1 2");
                sw.WriteLine("2 3");
                sw.WriteLine("3 4");
                sw.WriteLine("4 1");
            }
        }

        private void GenerateAdvancedTrueFile()
        {
            using (var sw = new StreamWriter(AdvancedTrueStatePath, false))
            {
                sw.WriteLine(7);
                sw.WriteLine();
                sw.WriteLine(3);
                sw.WriteLine();
                sw.WriteLine(2);
                sw.WriteLine(4);
                sw.WriteLine(6);
                sw.WriteLine();
                sw.WriteLine(6);
                sw.WriteLine();
                sw.WriteLine("1 2");
                sw.WriteLine("2 3");
                sw.WriteLine("3 4");
                sw.WriteLine("4 5");
                sw.WriteLine("3 6");
                sw.WriteLine("6 7");
            }
        }
    }
}