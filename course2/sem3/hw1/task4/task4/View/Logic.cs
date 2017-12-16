using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    /// <summary>
    /// Class of logic
    /// </summary>
    class Logic
    {
        private static Logic instance;
        private IShapeBuilder builder;
        private Model model;
        private Controller controller;
        private bool isMouseDown;
        private bool isMouseMove;
        private bool isCursorSelected;

        private Logic()
        {
            this.builder = new NullBuilder();
            this.model = new Model();
            this.controller = new Controller(this.model);
            this.isMouseDown = false;
            this.isMouseMove = false;
            this.isCursorSelected = false;
        }

        /// <summary>
        /// Get a singletone instance of the <see cref"Logic"/> class
        /// </summary>
        public static Logic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logic();
                }

                return instance;
            }
        }

        /// <summary>
        /// Unexecute action
        /// </summary>
        public void Undo()
        {
            this.controller.Undo();
        }

        /// <summary>
        /// Unexecute unexecuted action
        /// </summary>
        public void Redo()
        {
            this.controller.Redo();
        }

        /// <summary>
        /// Action when user clicks on draw area
        /// </summary>
        public void MouseDown(MouseEventArgs e)
        {
            this.isMouseDown = true;
            this.model.UnselectCurrent();

            if (!this.isCursorSelected)
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
            }
        }

        /// <summary>
        /// Action when user releases the mouse button
        /// </summary>
        public void MouseUp(MouseEventArgs e)
        {
            if (this.isMouseMove)
            {
                Line newLine = this.builder.GetProduct();

                if (!this.isCursorSelected)
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
            }

            this.isMouseDown = false;
            this.isMouseMove = false;
        }

        /// <summary>
        /// Action when user moves mouse
        /// </summary>
        public void MouseMove(MouseEventArgs e)
        {
            if (this.isMouseDown)
            {
                if (!this.isCursorSelected || (this.isCursorSelected && this.model.HasSelectedPoint))
                {
                    this.builder.Drag(new Point(e.X, e.Y));
                    this.isMouseMove = true;
                }

                if (this.isCursorSelected && this.model.HasSelectedPoint)
                {
                    this.model.SelectedLine.Visible = false;
                }
            }
        }

        /// <summary>
        /// Delete line
        /// </summary>
        public void DeleteLine()
        {
            Command removeElement = new RemoveCommand();
            this.controller.Handle(removeElement);
        }

        /// <summary>
        /// Draw all lines
        /// </summary>
        public void DrawLines()
        {
            this.builder = new LineBuilder();
            this.isCursorSelected = false;
        }

        /// <summary>
        /// Select lines
        /// </summary>
        public void SelectLines()
        {
            this.isCursorSelected = true;
        }

        /// <summary>
        /// Paint (very significant comment)
        /// </summary>
        public void Paint(PaintEventArgs e)
        {
            if (this.isMouseMove)
            {
                this.builder.Draw(e);
            }

            this.model.Draw(e);
        }
    }
}
