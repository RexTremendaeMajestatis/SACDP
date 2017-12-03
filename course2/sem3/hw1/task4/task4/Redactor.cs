using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    public partial class Redactor : Form
    {
        bool IsClicked = false;

        List<Line> Lines = new List<Line>();

        Point a;
        Point b;

        Pen pen = new Pen(Color.Black);
        public Redactor()
        {
            InitializeComponent();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {

        }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            IsClicked = true;
            a.X = e.X;
            a.Y = e.Y;
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;
            Lines.Add(new Line(a, b));
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsClicked)
            {
                b.X = e.X;
                b.Y = e.Y;
                DrawArea.Invalidate();
            }
        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, a, b);
            foreach (var line in Lines)
            {
                e.Graphics.DrawLine(pen, line.a, line.b);
            }
        }
    }
}
