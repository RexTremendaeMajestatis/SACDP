namespace Task4.Model
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.View;

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
        /// Check if line has selected point
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
        /// Unselect current line
        /// </summary>
        public void UnselectCurrent()
        {
            if (this.selectedLine != null)
            {
                this.selectedLine.Selected = false;
            }
        }

        /// <summary>
        /// Add line
        /// </summary>
        public void AddLine(Line line)
        {
            this.lines.Add(line);
            this.selectedLine = line;
            this.selectedLine.Visible = true;
            this.selectedLine.Selected = true;
        }

        /// <summary>
        /// Remove line
        /// </summary>
        public void RemoveLine(Line line)
        {
            this.lines.Remove(line);
        }

        /// <summary>
        /// Remove current line
        /// </summary>
        public void RemoveCurrentLine()
        {
            if (this.selectedLine != null)
            {
                this.lines.Remove(this.selectedLine);
            }
        }

        /// <summary>
        /// Draw all lines
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            foreach (var line in this.lines)
            {
                line.Draw(e);
            }
        }

        /// <summary>
        /// Find any line that belongs to epsilon area of point
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
