namespace Task4.Model
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.View;

    public sealed class Model
    {
        private List<Line> lines = new List<Line>();
        private Line selectedLine = null;

        public Line SelectedLine
        {
            get
            {
                return this.selectedLine;
            }

            set
            {
                this.UnselectCurrent();
                this.selectedLine = value;

                if (this.selectedLine != null)
                {
                    this.selectedLine.Selected = true;
                }
            }
        }

        public LineBuilder CurrentElementBuilder => this.selectedLine.Builder;

        public Point CurrentElementInitPoint => this.selectedLine.InitPoint;

        public bool HasSelectedPoint
        {
            get
            {
                if (this.selectedLine != null)
                {
                    return this.selectedLine.SelectedPoint != default(Point);
                }

                return false;
            }
        }

        public void UnselectCurrent()
        {
            if (this.selectedLine != null)
            {
                this.selectedLine.Selected = false;
            }
        }

        public void AddLine(Line line)
        {
            this.lines.Add(line);
            this.selectedLine = line;
            this.selectedLine.Visible = true;
            this.selectedLine.Selected = true;
        }

        public void RemoveLine(Line line)
        {
            this.lines.Remove(line);
        }

        public void RemoveCurrentLine()
        {
            if (this.selectedLine != null)
            {
                this.lines.Remove(this.selectedLine);
            }
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var line in this.lines)
            {
                line.Draw(e);
            }
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
