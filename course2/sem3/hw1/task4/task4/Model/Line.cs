namespace Task4.Model
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.View;

    public class Line 
    {
        private Pen pen = new Pen(Color.Black);
        private Point firstPoint;
        private Point secondPoint;

        public Line(Point firstPoint, Point secondPoint, LineBuilder builder)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.Builder = builder;
            this.Selected = false;
            this.Visible = true;
        }

        public bool Selected { get; set; }

        public bool Visible { get; set; }

        public LineBuilder Builder { get; set; }

        public Point InitPoint { get; set; }

        public Point SelectedPoint { get; set; }

        public void Draw(PaintEventArgs e)
        {
            if (this.Visible)
            {
                e.Graphics.DrawLine(this.pen, this.firstPoint, this.secondPoint);
                if (this.Selected)
                {
                    this.DrawSelection(e);
                }
            }
        }

        public bool Contain(Point point)
        {
            throw new NotImplementedException();
        }

        private void DrawSelection(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(this.pen, new Rectangle(this.firstPoint.X - 5, this.secondPoint.Y - 5, 10, 10));
            e.Graphics.DrawEllipse(this.pen, new Rectangle(this.firstPoint.X - 5, this.secondPoint.Y - 5, 10, 10));
        }
    }
}
