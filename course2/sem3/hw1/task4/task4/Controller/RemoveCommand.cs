namespace Task4.Controller
{
    using Task4.Model;

    class RemoveCommand: Command
    {
        private Line line;

        public RemoveCommand()
        {
        }

        public override void Execute(Model model)
        {
            this.line = model.CurrentLine;
            if (line != null)
            {
                model.RemoveLine(line);
            }
        }

        public override void Unexecute(Model model)
        {
            model.AddLine(this.line);
        }
    }
}
