namespace Task4.Controller
{
    using Task4.Model;

    public sealed class AddCommand : Command
    {
        private Line line;

        public AddCommand(Line line) => this.line = line;

        public override void Execute(Model model) => model.AddLine(this.line);

        public override void Unexecute(Model model) => model.RemoveLine(this.line);
    }
}
