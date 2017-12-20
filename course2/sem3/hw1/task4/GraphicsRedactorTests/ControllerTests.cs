namespace GraphicsEditorTests
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task4;
    
    /// <summary>
    /// Contriler & logic test class
    /// </summary>
    [TestClass]
    public class ControllerTests
    {
        private const string Path = "points.txt";

        private static readonly Model Model = new Model();
        private static readonly Controller Controller = new Controller(Model);

        private readonly List<Point> points = new List<Point>();
        private readonly List<Line> lines = new List<Line>();
        private readonly Point thirdLinePoint = new Point(391, 181);

        /// <summary>
        /// Select line test
        /// </summary>
        [TestMethod]
        public void SelectLineTest()
        {
            foreach (var line in this.lines)
            {
                var add = new AddCommand(line);
                Controller.Handle(add);
            }

            var select = new SelectLineCommand(this.thirdLinePoint);
            Controller.Handle(select);
            Assert.IsTrue(Model.SelectedLine.Selected);
            Assert.IsTrue(Model.SelectedLine == this.lines[2]);
        }

        /// <summary>
        /// Undo selection test (expected that previous line is selected)
        /// </summary>
        [TestMethod]
        public void SelectUndoTest()
        { 
            foreach (var line in this.lines)
            {
                var add = new AddCommand(line);
                Controller.Handle(add);
            }

            var select = new SelectLineCommand(this.thirdLinePoint);
            Controller.Handle(select);
            Controller.Undo();
            Assert.IsTrue(Model.SelectedLine.Selected);
            Assert.IsTrue(Model.SelectedLine == this.lines[3]);
            Assert.IsFalse(Model.Lines[2].Selected);
        }

        /// <summary>
        /// Redo selection test (expected that third line is selected)
        /// </summary>
        [TestMethod]
        public void SelectRedoTest()
        {
            foreach (var line in this.lines)
            {
                var add = new AddCommand(line);
                Controller.Handle(add);
            }

            var select = new SelectLineCommand(this.thirdLinePoint);
            Controller.Handle(select);
            Controller.Undo();
            Controller.Redo();
            Assert.IsTrue(Model.SelectedLine.Selected);
            Assert.IsTrue(Model.SelectedLine == this.lines[2]);
        }

        /// <summary>
        /// Adds lines from list and checks if model contains them
        /// </summary>
        [TestMethod]
        public void AddLineTest()
        {
            foreach (var line in this.lines)
            {
                var add = new AddCommand(line);
                Controller.Handle(add);
            }

            foreach (var line in this.lines)
            {
                Assert.IsTrue(Model.Lines.Contains(line));
            }
        }

        /// <summary>
        /// Adds line and checks if model does not contain it after undo
        /// </summary>
        [TestMethod]
        public void AddUndoTest()
        {
            var add = new AddCommand(this.lines[0]);
            Controller.Handle(add);
            Controller.Undo();
            Assert.IsFalse(Model.Lines.Contains(this.lines[0]));
        }

        /// <summary>
        /// Adds line and checks if model contains it after redo
        /// </summary>
        [TestMethod]
        public void AddRedoTest()
        {
            var add = new AddCommand(this.lines[0]);
            Controller.Handle(add);
            Controller.Undo();
            Controller.Redo();
            Assert.IsTrue(Model.Lines.Contains(this.lines[0]));
        }

        /// <summary>
        /// Removes line from model
        /// </summary>
        [TestMethod]
        public void RemoveLineTest()
        { 
            foreach (var line in this.lines)
            {
                var add = new AddCommand(line);
                Controller.Handle(add);
            }

            var remove = new RemoveCommand();
            Controller.Handle(remove);
            Assert.IsFalse(Model.Lines.Contains(this.lines[3]));
        }

        /// <summary>
        /// Removes line and then abort operation
        /// </summary>
        [TestMethod]
        public void RemoveUndoTest()
        {
            foreach (var line in this.lines)
            {
                var add = new AddCommand(line);
                Controller.Handle(add);
            }

            var remove = new RemoveCommand();
            Controller.Handle(remove);
            Controller.Undo();
            Assert.IsTrue(Model.Lines.Contains(this.lines[3]));
        }

        /// <summary>
        /// Removes line and then aborts aborting operation
        /// </summary>
        [TestMethod]
        public void RemoveRedoTest()
        {
            foreach (var line in this.lines)
            {
                var add = new AddCommand(line);
                Controller.Handle(add);
            }

            var remove = new RemoveCommand();
            Controller.Handle(remove);
            Controller.Undo();
            Controller.Redo();
            Assert.IsFalse(Model.Lines.Contains(this.lines[3]));
        }

        /// <summary>
        /// Moves line
        /// </summary>
        [TestMethod]
        public void MoveLineTest()
        {
            var add = new AddCommand(this.lines[0]);
            Controller.Handle(add);
            var move = new MoveCommand(this.lines[1]);
            Controller.Handle(move);
            Assert.IsFalse(Model.Lines.Contains(this.lines[0]));
            Assert.IsTrue(Model.Lines.Contains(this.lines[1]));
        }

        /// <summary>
        /// Moves line and then aborts operation
        /// </summary>
        [TestMethod]
        public void MoveUndoTest()
        {
            var add = new AddCommand(this.lines[0]);
            Controller.Handle(add);
            var move = new MoveCommand(this.lines[1]);
            Controller.Handle(move);
            Controller.Undo();
            Assert.IsTrue(Model.Lines.Contains(this.lines[0]));
            Assert.IsFalse(Model.Lines.Contains(this.lines[1]));
        }

        /// <summary>
        /// Moves line and then aborts aborting operation
        /// </summary>
        [TestMethod]
        public void MoveRedoTest()
        {
            var add = new AddCommand(this.lines[0]);
            Controller.Handle(add);
            var move = new MoveCommand(this.lines[1]);
            Controller.Handle(move);
            Controller.Undo();
            Controller.Redo();
            Assert.IsFalse(Model.Lines.Contains(this.lines[0]));
            Assert.IsTrue(Model.Lines.Contains(this.lines[1]));
        }

        /// <summary>
        /// Simulates user's behaviour
        /// </summary>
        [TestMethod]
        public void AdvancedTest()
        {
            var addFirstLine = new AddCommand(this.lines[0]);
            Controller.Handle(addFirstLine);
            Assert.IsTrue(Model.Lines.Contains(this.lines[0]));
            Controller.Undo();
            Assert.IsFalse(Model.Lines.Contains(this.lines[0]));
            Controller.Redo();
            Assert.IsTrue(Model.Lines.Contains(this.lines[0]));
            var remove = new RemoveCommand();
            Controller.Handle(remove);
            Assert.IsFalse(Model.Lines.Contains(this.lines[0]));
            Controller.Undo();
            Assert.IsTrue(Model.Lines.Contains(this.lines[0]));
            var addSecondLine = new AddCommand(this.lines[1]);
            Controller.Handle(addSecondLine);
            Assert.IsTrue(Model.Lines.Contains(this.lines[1]));
            var selectFirstLine = new SelectLineCommand(new Point(31, 81));
            Controller.Handle(selectFirstLine);
            Assert.IsTrue(Model.SelectedLine == this.lines[0]);
            var moveFirstLine = new MoveCommand(this.lines[2]);
            Controller.Handle(moveFirstLine);
            Assert.IsFalse(Model.Lines.Contains(this.lines[0]));
            Controller.Undo();
            Controller.Undo();
            Assert.IsFalse(Model.SelectedLine == this.lines[0]);
            Assert.IsFalse(Model.Lines.Contains(this.lines[2]));
        }

        /// <summary>
        /// Loads lines from file
        /// </summary>
        [TestInitialize]
        public void LoadLines()
        {
            this.CreatePoints(Path);
            this.LoadPoints(Path);
            this.lines.Clear();

            for (int i = 0; i < this.points.Count - 1; i += 2)
            {
                this.lines.Add(new Line(this.points[i], this.points[i + 1]));
            }
        }

        /// <summary>
        /// Loads points from file
        /// </summary>
        private void LoadPoints(string path)
        {
            this.points.Clear();

            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    while (!file.EndOfStream)
                    {
                        string point = file.ReadLine();
                        string[] coords = point.Split(' ');
                        var temp = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                        this.points.Add(temp);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Generates points in file
        /// </summary>
        private void CreatePoints(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("30 80");
                sw.WriteLine("90 40");
                sw.WriteLine("-20 100");
                sw.WriteLine("30 990");
                sw.WriteLine("220 80");
                sw.WriteLine("390 180");
                sw.WriteLine("10 500");
                sw.WriteLine("170 980");
            }
        }
    }
}
