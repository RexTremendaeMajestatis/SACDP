namespace Task4
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Model class
    /// </summary>
    public sealed class Model
    {
        private List<Line> lines = new List<Line>();
        private Line selectedLine = null;

        /// <summary>
        /// Line that selected
        /// </summary>
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

        /// <summary>
        /// Current element builder
        /// </summary>
        public LineBuilder CurrentElementBuilder => this.selectedLine.Builder;

        /// <summary>
        /// Current initialization point
        /// </summary>
        public Point CurrentElementInitPoint => this.selectedLine.InitPoint;

        /// <summary>
        /// Checks if line has selected point
        /// </summary>
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

        /// <summary>
        /// Unselects current line
        /// </summary>
        public void UnselectCurrent()
        {
            if (this.selectedLine != null)
            {
                this.selectedLine.Selected = false;
            }
        }

        /// <summary>
        /// Adds line
        /// </summary>
        public void AddLine(Line line)
        {
            this.UnselectCurrent();
            this.lines.Add(line);
            this.selectedLine = line;
            this.selectedLine.Visible = true;
            this.selectedLine.Selected = true;
        }

        /// <summary>
        /// Removes line
        /// </summary>
        public void RemoveLine(Line line)
        {
            this.lines.Remove(line);
        }

        /// <summary>
        /// Removes current line
        /// </summary>
        public void RemoveSelectedLine()
        {
            if (this.selectedLine != null)
            {
                this.lines.Remove(this.selectedLine);
            }
        }

        /// <summary>
        /// Draws all lines
        /// </summary>
        public void Draw(PaintEventArgs e)
        {
            foreach (var line in this.lines)
            {
                line.Draw(e);
            }
        }

        /// <summary>
        /// Finds any line that belongs to epsilon area of point
        /// </summary>
        /// <param name="point">Point of epsilon area</param>
        /// <returns>Return the last added line</returns>
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
