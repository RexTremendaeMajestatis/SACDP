namespace Task4.View
{
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.Model;

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
