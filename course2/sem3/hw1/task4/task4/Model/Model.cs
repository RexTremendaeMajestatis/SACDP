namespace Task4.Model
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.View;

    public class Model
    {
        private List<Line> lines = new List<Line>();
        private Line currentLine = null;

        public Model()
        {
        }

        public Line CurrentLine
        {
            get
            {
                return this.currentLine;
            }

            set
            {
                this.UnselectCurrent();
                this.currentLine = value;

                if (this.currentLine != null)
                {
                    this.currentLine.Selected = true;
                }
            }
        }

        public LineBuilder GetCurrentElementBuilder() => this.currentLine.Builder;

        public Point GetCurrentElementInitPoint() => this.currentLine.InitPoint;

        public void UnselectCurrent()
        {
            if (this.currentLine != null)
            {
                this.currentLine.Selected = false;
            }
        }

        public void AddLine(Line line)
        {
            this.lines.Add(line);
            this.currentLine = line;
            this.currentLine.Visible = true;
            this.currentLine.Selected = true;
        }

        public void RemoveLine(Line line)
        {
            this.lines.Remove(line);
        }

        public void RemoveCurrentLine()
        {
            if (this.currentLine != null)
            {
                this.lines.Remove(this.currentLine);
            }
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var line in this.lines)
            {
                line.Draw(e);
            }
        }

        public bool HasSelectedPoint()
        {
            if (this.currentLine != null)
            {
                return this.currentLine.SelectedPoint != default(Point);
            }

            return false;
        }

        public Line FindIntersection(Point point)
        {
            int i = this.lines.Count - 1;
            while (i >= 0 && !this.lines[i].Contain(point))
            {
                i--;
            }

            if (i >= 0)
            {
                return this.lines[i];
            }

            return null;
        }
    }
}
