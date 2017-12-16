namespace Task4
{
    /// <summary>
    /// Move command class
    /// </summary>
    public sealed class MoveCommand : Command
    {
        private Line newLine;
        private Line oldLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveCommand"/> class
        /// </summary>
        public MoveCommand(Line newLine) => this.newLine = newLine;

        /// <summary>
        /// Execute move command
        /// </summary>
        public override void Execute(Model model)
        {
            this.oldLine = model.SelectedLine;
            model.RemoveSelectedLine();
            model.AddLine(this.newLine);
        }

        /// <summary>
        /// Unexecute move command
        /// </summary>
        public override void Unexecute(Model model)
        {
            model.RemoveLine(this.newLine);
            model.AddLine(this.oldLine);
        }
    }
}
