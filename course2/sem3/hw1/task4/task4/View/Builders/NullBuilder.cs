namespace Task4
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Builder for nothing but for something
    /// </summary>
    class NullBuilder : IShapeBuilder
    {
        public void Init(Point point) { }
        public void Drag(Point point) { }
        public void Draw(PaintEventArgs e) { }
        public Line GetProduct() => null;
    }
}
