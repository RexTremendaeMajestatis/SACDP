namespace Task4.View
{
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.Model;

    public interface IShapeBuilder
    {
        void Init(Point point);

        void Move(Point point);

        void Draw(PaintEventArgs e);

        Line GetProduct();
    }
}
