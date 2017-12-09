namespace Task4.Controller
{
    using Task4.Model;

    public sealed class MoveCommand : Command
    {
        private Line newLine;
        private Line oldLine;

        public MoveCommand(Line newLine) => this.newLine = newLine;

        public override void Execute(Model model)
        {
            this.oldLine = model.SelectedLine;
            model.RemoveCurrentLine();
            model.AddLine(this.newLine);
        }

        public override void Unexecute(Model model)
        {
            model.RemoveLine(this.newLine);
            model.AddLine(this.oldLine);
        }
    }
}
