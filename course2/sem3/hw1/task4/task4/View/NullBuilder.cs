namespace Task4.View
{
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.Model;


    class NullBuilder : IShapeBuilder
    {
        public void Init(Point point) { }
        public void Move(Point point) { }
        public void Draw(PaintEventArgs e) { }
        public Line GetProduct() => null;
    }
}
