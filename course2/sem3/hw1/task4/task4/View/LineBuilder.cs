namespace Task4.View
{
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.Model;

    public class LineBuilder
    {
        private Point firstPoint;
        private Point secondPoint;

        public LineBuilder() { }

        public void Init(Point point)
        {
            this.firstPoint = point;
        }

        public void Move(Point point)
        {
            this.secondPoint = point;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), this.firstPoint, this.secondPoint);
        }

        public Line GetProduct() => new Line(this.firstPoint, this.secondPoint, this);
    }
}
