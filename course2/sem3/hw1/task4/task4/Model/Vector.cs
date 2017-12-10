namespace Task4.Model
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Vector class
    /// </summary>
    public sealed class Vector
    {
        private Point end;

        /// <summary>
        /// Initializes the new instance of <see cref="Vector"/> class
        /// </summary>
        public Vector(Point point)
        {
            this.end = point;
        }

        /// <summary>
        /// Initializes the new instance of <see cref="Vector"/> class
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
        /// Vector stretching
        /// </summary>
        public static Vector operator *(int alpha, Vector vector)
        {
            return new Vector(new Point(vector.end.X * alpha, vector.end.Y * alpha));
        }

        /// <summary>
        /// Vector stretching
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