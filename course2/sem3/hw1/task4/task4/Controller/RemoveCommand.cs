namespace Task4.Controller
{
    using Task4.Model;

    public sealed class RemoveCommand : Command
    {
        private Line line;

        public RemoveCommand()
        {
        }

        public override void Execute(Model model)
        {
            this.line = model.CurrentLine;
            if (this.line != null)
            {
                model.RemoveLine(this.line);
            }
        }

        public override void Unexecute(Model model)
        {
            model.AddLine(this.line);
        }
    }
}
