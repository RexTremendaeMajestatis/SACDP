namespace GraphicsEditorTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task4;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;

    [TestClass]
    public class ControllerTests
    {
        private static readonly Model model = new Model();
        private static readonly Controller controller = new Controller(model);

        private List<Point> points = new List<Point>();
        private List<Line> lines = new List<Line>();

        private readonly Point thirdLinePoint = new Point(391, 181);

        private const string path = "points.txt";

        /// <summary>
        /// Select line test
        /// </summary>
        [TestMethod]
        public void SelectLineTest()
        {
            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            var select = new SelectLineCommand(thirdLinePoint);
            controller.Handle(select);
            Assert.IsTrue(model.SelectedLine.Selected);
            Assert.IsTrue(model.SelectedLine == lines[2]);
        }

        /// <summary>
        /// Undo selection test (expected that previous line is selected)
        /// </summary>
        [TestMethod]
        public void SelectUndoTest()
        { 
            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            var select = new SelectLineCommand(thirdLinePoint);
            controller.Handle(select);
            controller.Undo();
            Assert.IsTrue(model.SelectedLine.Selected);
            Assert.IsTrue(model.SelectedLine == lines[3]);
            Assert.IsFalse(model.Lines[2].Selected);
        }

        /// <summary>
        /// Redo selection test (expected that third line is selected)
        /// </summary>
        [TestMethod]
        public void SelectRedoTest()
        {
            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            var select = new SelectLineCommand(thirdLinePoint);
            controller.Handle(select);
            controller.Undo();
            controller.Redo();
            Assert.IsTrue(model.SelectedLine.Selected);
            Assert.IsTrue(model.SelectedLine == lines[2]);
        }

        /// <summary>
        /// Adds lines from list and checks if model contains them
        /// </summary>
        [TestMethod]
        public void AddLineTest()
        {
            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            foreach (var line in lines)
            {
                Assert.IsTrue(model.Lines.Contains(line));
            }
        }

        /// <summary>
        /// Adds line and checks if model does not contain it after undo
        /// </summary>
        [TestMethod]
        public void AddUndoTest()
        {
            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            controller.Undo();
            Assert.IsFalse(model.Lines.Contains(lines[0]));
        }

        /// <summary>
        /// Adds line and checks if model contains it after redo
        /// </summary>
        [TestMethod]
        public void AddRedoTest()
        {
            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            controller.Undo();
            controller.Redo();
            Assert.IsTrue(model.Lines.Contains(lines[0]));
        }

        /// <summary>
        /// Removes line from model
        /// </summary>
        [TestMethod]
        public void RemoveLineTest()
        { 
            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            var remove = new RemoveCommand();
            controller.Handle(remove);
            Assert.IsFalse(model.Lines.Contains(lines[3]));
        }

        /// <summary>
        /// Removes line and then abort operation
        /// </summary>
        [TestMethod]
        public void RemoveUndoTest()
        {
            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            var remove = new RemoveCommand();
            controller.Handle(remove);
            controller.Undo();
            Assert.IsTrue(model.Lines.Contains(lines[3]));
        }

        /// <summary>
        /// Removes line and then aborts aborting operation
        /// </summary>
        [TestMethod]
        public void RemoveRedoTest()
        {
            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            var remove = new RemoveCommand();
            controller.Handle(remove);
            controller.Undo();
            controller.Redo();
            Assert.IsFalse(model.Lines.Contains(lines[3]));
        }

        /// <summary>
        /// Moves line
        /// </summary>
        [TestMethod]
        public void MoveLineTest()
        {
            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            var move = new MoveCommand(lines[1]);
            controller.Handle(move);
            Assert.IsFalse(model.Lines.Contains(lines[0]));
            Assert.IsTrue(model.Lines.Contains(lines[1]));
        }

        /// <summary>
        /// Moves line and then aborts operation
        /// </summary>
        [TestMethod]
        public void MoveUndoTest()
        {
            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            var move = new MoveCommand(lines[1]);
            controller.Handle(move);
            controller.Undo();
            Assert.IsTrue(model.Lines.Contains(lines[0]));
            Assert.IsFalse(model.Lines.Contains(lines[1]));
        }

        /// <summary>
        /// Moves line and then aborts aborting operation
        /// </summary>
        [TestMethod]
        public void MoveRedoTest()
        {
            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            var move = new MoveCommand(lines[1]);
            controller.Handle(move);
            controller.Undo();
            controller.Redo();
            Assert.IsFalse(model.Lines.Contains(lines[0]));
            Assert.IsTrue(model.Lines.Contains(lines[1]));
        }

        /// <summary>
        /// Simulates user's behaviour
        /// </summary>
        [TestMethod]
        public void AdvancedTest()
        {
            var addFirstLine = new AddCommand(lines[0]);
            controller.Handle(addFirstLine);
            Assert.IsTrue(model.Lines.Contains(lines[0]));
            controller.Undo();
            Assert.IsFalse(model.Lines.Contains(lines[0]));
            controller.Redo();
            Assert.IsTrue(model.Lines.Contains(lines[0]));
            var remove = new RemoveCommand();
            controller.Handle(remove);
            Assert.IsFalse(model.Lines.Contains(lines[0]));
            controller.Undo();
            Assert.IsTrue(model.Lines.Contains(lines[0]));
            var addSecondLine = new AddCommand(lines[1]);
            controller.Handle(addSecondLine);
            Assert.IsTrue(model.Lines.Contains(lines[1]));
            var selectFirstLine = new SelectLineCommand(new Point(31, 81));
            controller.Handle(selectFirstLine);
            Assert.IsTrue(model.SelectedLine == lines[0]);
            var moveFirstLine = new MoveCommand(lines[2]);
            controller.Handle(moveFirstLine);
            Assert.IsFalse(model.Lines.Contains(lines[0]));
            controller.Undo();
            controller.Undo();
            Assert.IsFalse(model.SelectedLine == lines[0]);
            Assert.IsFalse(model.Lines.Contains(lines[2]));
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
                        points.Add(temp);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    System.Console.WriteLine(ex.Message);
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

        /// <summary>
        /// Loads lines from file
        /// </summary>
        [TestInitialize]
        public void LoadLines()
        {
            this.CreatePoints(path);
            this.LoadPoints(path);
            this.lines.Clear();

            for (int i = 0; i < this.points.Count - 1; i += 2)
            {
                lines.Add(new Line(this.points[i], this.points[i + 1]));
            }
        }
    }
}
