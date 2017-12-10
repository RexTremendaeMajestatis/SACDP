namespace Task4.View
{
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.Model;

    public sealed class LineBuilder : IShapeBuilder
    {
        private Point firstPoint;
        private Point secondPoint;

        /// <summary>
        /// Sets first point of line before draging
        /// </summary>
        public void Init(Point point)
        {
            this.firstPoint = point;
        }

        /// <summary>
        /// Sets second point while draging
        /// </summary>
        public void Drag(Point point)
        {
            this.secondPoint = point;
        }

        /// <summary>
        /// Draws line
        /// </summary>
        public void Draw(PaintEventArgs e) => e.Graphics.DrawLine(new Pen(Color.Black), this.firstPoint, this.secondPoint);

        /// <summary>
        /// Get created line
        /// </summary>
        public Line GetProduct() => new Line(this.firstPoint, this.secondPoint, this);
    }
}
