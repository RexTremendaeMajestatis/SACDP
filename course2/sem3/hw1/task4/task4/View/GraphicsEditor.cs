namespace Task4
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Task4.View;
    using Task4.Model;
    using Task4.Controller;

    public partial class GraphicsEditor : Form
    {
        private IShapeBuilder builder = new NullBuilder();

        private Model.Model model;
        private Controller.Controller controller;

        private bool mouseDown = false;
        private bool mouseMove = false;
        private bool cursorSelected = false;

        public GraphicsEditor()
        {
            this.model = new Model.Model();
            this.controller = new Controller.Controller(this.model);
            this.InitializeComponent();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            this.controller.Undo();
            DrawArea.Invalidate();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            this.controller.Redo();
            DrawArea.Invalidate();
        }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.model.UnselectCurrent();

            if (!this.cursorSelected)
            {
                this.builder.Init(new Point(e.X, e.Y));
            }
            else
            {
                Command selectCommand = new SelectLineCommand(new Point(e.X, e.Y));
                this.controller.Handle(selectCommand);

                if (this.model.HasSelectedPoint)
                {
                    this.builder = this.model.CurrentElementBuilder;
                    this.builder.Init(this.model.CurrentElementInitPoint);
                }

                DrawArea.Invalidate();
            }
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.mouseMove)
            {
                Line newLine = this.builder.GetProduct();

                if (!this.cursorSelected)
                {
                    if (newLine != null)
                    {
                        Command addCommand = new AddCommand(newLine);
                        this.controller.Handle(addCommand);
                    }
                }
                else if (this.model.HasSelectedPoint)
                {
                    Command moveCommand = new MoveCommand(newLine);
                    this.controller.Handle(moveCommand);
                }

                DrawArea.Invalidate();
            }

            this.mouseDown = false;
            this.mouseMove = false;
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown)
            {
                if (!this.cursorSelected || (this.cursorSelected && this.model.HasSelectedPoint))
                {
                    this.builder.Drag(new Point(e.X, e.Y));
                    this.mouseMove = true;
                }

                if (this.cursorSelected && this.model.HasSelectedPoint)
                {
                    this.model.SelectedLine.Visible = false;
                }

                DrawArea.Invalidate();
            }
        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            if (this.mouseMove)
            {
                this.builder.Draw(e);
            }

            this.model.Draw(e);
        }

        private void DeleteLineButton_Click(object sender, EventArgs e)
        {
            Command removeElement = new RemoveCommand();
            this.controller.Handle(removeElement);
            DrawArea.Invalidate();
        }

        private void DrawLinesButton_Click(object sender, EventArgs e)
        {
            this.builder = new LineBuilder();
            DrawLinesButton.BackColor = Color.Gray;
            this.cursorSelected = false;
            SelectLinesButton.BackColor = Color.Empty;
        }

        private void SelectLinesButton_Click(object sender, EventArgs e)
        {
            this.cursorSelected = true;
            DrawLinesButton.BackColor = Color.Empty;
            SelectLinesButton.BackColor = Color.Gray;
        }
    }
}
