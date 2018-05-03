namespace Task4
{
    using System.Collections.Generic;

    /// <summary>
    /// Controller class
    /// </summary>
    public sealed class Controller
    {
        private Model model;
        private Stack<Command> undoStack;
        private Stack<Command> redoStack;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class
        /// </summary>
        public Controller(Model model)
        {
            this.model = model;
            this.undoStack = new Stack<Command>();
            this.redoStack = new Stack<Command>();
        }

        /// <summary>
        /// Checks if there are any commands to undo
        /// </summary>
        public bool HasUndo => undoStack.Count != 0;

        /// <summary>
        /// Checks if there ane any commands to redo
        /// </summary>
        public bool HasRedo => redoStack.Count != 0;

        /// <summary>
        /// Handle command
        /// </summary>
        public void Handle(Command command)
        {
            if (command.Significant(this.model))
            {
                this.undoStack.Push(command);
                this.redoStack.Clear();
                command.Execute(this.model);
            }
        }

        /// <summary>
        /// Cancel last action
        /// </summary>
        public void Undo()
        {
            if (this.undoStack.Count != 0)
            {
                this.undoStack.Peek().Unexecute(this.model);
                this.redoStack.Push(this.undoStack.Peek());
                this.undoStack.Pop();
            }
        }

        /// <summary>
        /// Cancel cancelling of last action
        /// </summary>
        public void Redo()
        {
            if (this.redoStack.Count != 0)
            {
                this.redoStack.Peek().Execute(this.model);
                this.undoStack.Push(this.redoStack.Peek());
                this.redoStack.Pop();
            }
        }
    }
}
