namespace Task4.Controller
{
    using System.Collections.Generic;
    using Model;

    public sealed class Controller
    {
        private List<Command> listUndoRedo;
        private Model model;
        private int pointer;

        /// <summary>
        /// Initializes the new instance of <see cref="Controller"> class
        /// </summary>
        public Controller(Model model)
        {
            this.model = model;
            this.listUndoRedo = new List<Command>();
            this.pointer = -1;
        }

        /// <summary>
        /// Handle command
        /// </summary>
        public void Handle(Command command)
        {
            if (command.Significant(this.model))
            {
                this.pointer++;
                this.listUndoRedo.Insert(this.pointer, command);
                command.Execute(this.model);
                this.CleanListTail();
            }
        }

        /// <summary>
        /// Cancel last action
        /// </summary>
        public void Undo()
        {
            if (this.pointer > -1)
            {
                this.listUndoRedo[this.pointer].Unexecute(this.model);
                this.pointer--;
            }
        }

        /// <summary>
        /// Cancel cancelling of last action
        /// </summary>
        public void Redo()
        {
            if (this.pointer < this.listUndoRedo.Count - 1)
            {
                this.pointer++;
                this.listUndoRedo[this.pointer].Execute(this.model);
            }
        }

        private void CleanListTail()
        {
            for (int i = this.pointer + 1; i < this.listUndoRedo.Count; i++)
            {
                this.listUndoRedo.RemoveAt(i);
            }
        }
    }
}
