namespace Task4.Model
{
    using System;
    using System.Drawing;

    public class Vector
    {
        private Point end;

        public Vector(Point point)
        {
            this.end = point;
        }

        public Vector(Point beginPoint, Point endPoint)
        {
            this.end = new Point(endPoint.X - beginPoint.X, endPoint.Y - beginPoint.Y);
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(ScalarMultiply(this, this));
            }
        }

        public static Vector operator *(int alpha, Vector vector)
        {
            return new Vector(new Point(vector.end.X * alpha, vector.end.Y * alpha));
        }

        public static Vector operator *(Vector vector, int alpha)
        {
            return new Vector(new Point(vector.end.X * alpha, vector.end.Y * alpha));
        }

        public static int ScalarMultiply(Vector firstVector, Vector secondVector)
        {
            return (firstVector.end.X * secondVector.end.X) + (firstVector.end.Y * secondVector.end.Y);
        }
    }
}