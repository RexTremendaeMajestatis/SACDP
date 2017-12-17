namespace GraphicsEditorTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task4;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text;

    [TestClass]
    public class LogicTests
    {
        private static Model model = new Model();
        private static Controller controller = new Controller(model);
        private IShapeBuilder builder = new LineBuilder();

        private List<Point> points = new List<Point>();
        private List<Line> lines = new List<Line>();

        private string path = "points.txt";

        [TestMethod]
        public void AddLineTest()
        {
            LoadLines();
            
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

        [TestMethod]
        public void AddUndoTest()
        {
            LoadLines();

            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            controller.Undo();
            Assert.IsFalse(model.Lines.Contains(lines[0]));
        }

        [TestMethod]
        public void AddRedoTest()
        {
            LoadLines();

            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            controller.Undo();
            controller.Redo();
            Assert.IsTrue(model.Lines.Contains(lines[0]));
        }

        [TestMethod]
        public void RemoveLineTest()
        {
            LoadLines();

            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }

            var remove = new RemoveCommand();
            controller.Handle(remove);
            Assert.IsFalse(model.Lines.Contains(lines[3]));
        }

        [TestMethod]
        public void RemoveUndoTest()
        {
            LoadLines();

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

        [TestMethod]
        public void RemoveRedoTest()
        {
            LoadLines();

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

        [TestMethod]
        public void MoveLineTest()
        {
            LoadLines();

            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            var move = new MoveCommand(lines[1]);
            controller.Handle(move);
            Assert.IsFalse(model.Lines.Contains(lines[0]));
            Assert.IsTrue(model.Lines.Contains(lines[1]));
        }

        [TestMethod]
        public void MoveUndoTest()
        {
            LoadLines();

            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            var move = new MoveCommand(lines[1]);
            controller.Handle(move);
            controller.Undo();
            Assert.IsTrue(model.Lines.Contains(lines[0]));
            Assert.IsFalse(model.Lines.Contains(lines[1]));
        }

        [TestMethod]
        public void MoveRedoTest()
        {
            LoadLines();

            var add = new AddCommand(lines[0]);
            controller.Handle(add);
            var move = new MoveCommand(lines[1]);
            controller.Handle(move);
            controller.Undo();
            controller.Redo();
            Assert.IsFalse(model.Lines.Contains(lines[0]));
            Assert.IsTrue(model.Lines.Contains(lines[1]));
        }

        [TestMethod]
        public void SelectLineTest()
        {
            LoadLines();

            foreach (var line in lines)
            {
                var add = new AddCommand(line);
                controller.Handle(add);
            }
        }

        private void LoadPoints(string path)
        {
            this.points = new List<Point>();

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
                catch
                {

                }
            }
        }

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

        private void LoadLines()
        {
            CreatePoints(path);
            LoadPoints(path);

            for (int i = 0; i < points.Count - 1; i+=2)
            {
                lines.Add(new Line(points[i], points[i + 1]));
            }
        }
    }
}
