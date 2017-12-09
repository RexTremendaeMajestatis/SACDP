namespace Task4.Model
{
    using System.Collections.Generic;
    using System.Windows.Forms;

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

        public void AddLine(Line line)
        {
            this.lines.Add(line);
            this.currentLine = line;
            this.currentLine.Visible = true;
            this.currentLine.Selected = true;
        }

        public void RemoveCurrentLine()
        {
            if (this.currentLine != null)
            {
                this.lines.Remove(this.currentLine);
            }
        }

        public void RemoveLine(Line line)
        {
            this.lines.Remove(line);
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var line in this.lines)
            {
                line.Draw(e);
            }
        }

        public void UnselectCurrent()
        {
            if (this.currentLine != null)
            {
                this.currentLine.Selected = false;
            }
        }
    }
}
