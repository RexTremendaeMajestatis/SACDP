namespace Task4
{

    /// <summary>
    /// Remove command class
    /// </summary>
    public sealed class RemoveCommand : Command
    {
        private Line line;

        /// <summary>
        /// Execute remove command
        /// </summary>
        public override void Execute(Model model)
        {
            this.line = model.SelectedLine;
            if (this.line != null)
            {
                model.RemoveLine(this.line);
            }
        }

        /// <summary>
        /// Unexecute remove command
        /// </summary>
        public override void Unexecute(Model model) => model.AddLine(this.line);
    }
}
