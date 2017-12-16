namespace Task4.Controller
{
    using Task4.Model;

    /// <summary>
    /// Add command class
    /// </summary>
    public sealed class AddCommand : Command
    {
        private Line line;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommand"/> class
        /// </summary>
        public AddCommand(Line line) => this.line = line;

        /// <summary>
        /// Execute add command class
        /// </summary>
        public override void Execute(Model model) => model.AddLine(this.line);

        /// <summary>
        /// Unexecute command class
        /// </summary>
        public override void Unexecute(Model model) => model.RemoveLine(this.line);
    }
}
