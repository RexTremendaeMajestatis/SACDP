namespace Task4
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Line class
    /// </summary>
    public sealed class Line 
    {
        private Pen pen = new Pen(Color.Black);
        private Pen selectionPen = new Pen(Color.Red, 3);
        private Point fPoint;
        private Point sPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class
        /// </summary>
        /// <param name="firstPoint">First coordinate</param>
        /// <param name="secondPoint">Second coordinate</param>
        /// <param name="builder">Builder for line</param>
        public Line(Point firstPoint, Point secondPoint, LineBuilder builder)
        {
            this.fPoint = firstPoint;
            this.sPoint = secondPoint;
            this.Builder = builder;
            this.Selected = false;
            this.Visible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"> class
        /// </summary>
        /// <param name="firstPoint">First coordinate</param>
        /// <param name="secondPoint">Second coordinate</param>
        public Line(Point firstPoint, Point secondPoint)
        {
            this.fPoint = firstPoint;
            this.sPoint = secondPoint;
        }

        /// <summary>
        /// Is line selected
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Is line visible
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Builder fr line
        /// </summary>
        public LineBuilder Builder { get; set; }

        /// <summary>
        /// Initialization point
        /// </summary>
        public Point InitPoint { get; set; }

        /// <summary>
        /// Selected point
        /// </summary>
        public Point SelectedPoint { get; set; }

        /// <summary>
        /// Draws line on plot and selects it
        /// </summary>
        public void Draw(PaintEventArgs e)
        {
            if (this.Visible)
            {
                e.Graphics.DrawLine(this.pen, this.fPoint, this.sPoint);
                if (this.Selected)
                {
                    this.DrawSelection(e);
                }
            }
        }

        /// <summary>
        /// Checks if begining or end of line contains the point in epsilon area
        /// </summary>
        public bool Contain(Point point)
        {
            if (this.Distance(point) <= 15)
            {
                this.Selected = true;

                return true;
            }

            return false;
        }
        
        private double Distance(Point point)
        {
            var vectorA = new Vector(this.fPoint, point);
            var vectorB = new Vector(this.fPoint, this.sPoint);

            if (Vector.ScalarMultiply(vectorA, vectorB) < 0.0)
            {
                this.SelectedPoint = this.fPoint;
                this.InitPoint = this.sPoint;

                return vectorA.Length;
            }
            else
            {
                var vectorC = new Vector(this.sPoint, point);
                var vectorD = (-1) * vectorB;

                if (Vector.ScalarMultiply(vectorC, vectorD) < 0.0)
                {
                    this.SelectedPoint = this.sPoint;
                    this.InitPoint = this.fPoint;

                    return vectorC.Length;
                }
                else
                {
                    this.SelectedPoint = default(Point);
                    this.InitPoint = default(Point);

                    double cosAlpha = Vector.ScalarMultiply(vectorC, vectorD) / (vectorC.Length * vectorD.Length);
                    double sinAlpha = Math.Sqrt(1 - (cosAlpha * cosAlpha));

                    return sinAlpha * vectorC.Length;
                }
            }
        }

        private void DrawSelection(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(this.selectionPen, new Rectangle(this.fPoint.X - 2, this.fPoint.Y - 2, 4, 4));
            e.Graphics.DrawEllipse(this.selectionPen, new Rectangle(this.sPoint.X - 2, this.sPoint.Y - 2, 4, 4));
            e.Graphics.DrawLine(this.selectionPen, this.fPoint, this.sPoint);
        }
    }

    /// <summary>
    /// Vector class
    /// </summary>
    public sealed class Vector
    {
        private Point end;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class
        /// </summary>
        public Vector(Point point)
        {
            this.end = point;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class
        /// </summary>
        public Vector(Point beginPoint, Point endPoint)
        {
            this.end = new Point(endPoint.X - beginPoint.X, endPoint.Y - beginPoint.Y);
        }

        /// <summary>
        /// Vector length
        /// </summary>
        public double Length => Math.Sqrt(ScalarMultiply(this, this));

        /// <summary>
        /// <see cref="Vector"/> stretching
        /// </summary>
        public static Vector operator *(int alpha, Vector vector)
        {
            return new Vector(new Point(vector.end.X * alpha, vector.end.Y * alpha));
        }

        /// <summary>
        /// <see cref="Vector"/> stretching
        /// </summary>
        public static Vector operator *(Vector vector, int alpha)
        {
            return new Vector(new Point(vector.end.X * alpha, vector.end.Y * alpha));
        }

        /// <summary>
        /// Scalar product of two vectors
        /// </summary>
        public static int ScalarMultiply(Vector firstVector, Vector secondVector)
        {
            return (firstVector.end.X * secondVector.end.X) + (firstVector.end.Y * secondVector.end.Y);
        }
    }
}