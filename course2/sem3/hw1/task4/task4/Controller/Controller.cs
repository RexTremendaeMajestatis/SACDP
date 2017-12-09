namespace Task4.Controller
{
    using System.Collections.Generic;
    using Model;
    public sealed class Controller
    {
        List<Command> listUndoRedo;
        private Model model;
        private int pointer;

        public Controller(Model model)
        {
            this.model = model;
            listUndoRedo = new List<Command>();
            pointer = -1;
        }

        public void Handle(Command command)
        {
            if (command.Significant(this.model))
            {
                this.pointer++;
                this.listUndoRedo.Insert(pointer, command);
                command.Execute(this.model);
                CleanListTail();
            }
        }

        public void Undo()
        {
            if (pointer > 1)
            {
                this.listUndoRedo[pointer].Unexecute(this.model);
                pointer--;
            }
        }

        public void Redo()
        {
            if (pointer < this.listUndoRedo.Count - 1)
            {
                pointer++;
                this.listUndoRedo[pointer].Execute(this.model);
            }
        }

        private void CleanListTail()
        {
            for (int i = pointer + 1; i < listUndoRedo.Count; i++)
            {
                listUndoRedo.RemoveAt(i);
            }
        }
    }
}
