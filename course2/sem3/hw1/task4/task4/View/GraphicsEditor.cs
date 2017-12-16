namespace Task4
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Class of graphics editor form
    /// </summary>
    public partial class GraphicsEditor : Form
    {
        private Logic logic = Logic.Instance;
        
        public GraphicsEditor()
        {
            this.InitializeComponent();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            logic.Undo();
            DrawArea.Invalidate();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            logic.Redo();
            DrawArea.Invalidate();
        }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            logic.MouseDown(e);
            DrawArea.Invalidate();
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            logic.MouseUp(e);
            DrawArea.Invalidate();
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            logic.MouseMove(e);
            DrawArea.Invalidate();
        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            logic.Paint(e);
        }

        private void DeleteLineButton_Click(object sender, EventArgs e)
        {
            logic.DeleteLine();
            DrawArea.Invalidate();
        }

        private void DrawLinesButton_Click(object sender, EventArgs e)
        {
            logic.DrawLines();
            DrawLinesButton.BackColor = Color.Gray;
            SelectLinesButton.BackColor = Color.Empty;
        }

        private void SelectLinesButton_Click(object sender, EventArgs e)
        {
            logic.SelectLines();
            DrawLinesButton.BackColor = Color.Empty;
            SelectLinesButton.BackColor = Color.Gray;
        }
    }
}
