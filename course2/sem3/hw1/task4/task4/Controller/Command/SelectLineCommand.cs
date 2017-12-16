namespace Task4
{
    using System.Drawing;

    /// <summary>
    /// Selected line command class
    /// </summary>
    public sealed class SelectLineCommand : Command
    {
        private Point point;
        private Line newSelectedLine;
        private Line oldSelectedLine;

        /// <summary>
        /// Returns command of selecting line
        /// </summary>
        public SelectLineCommand(Point point) => this.point = point;

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute(Model model) => model.SelectedLine = this.newSelectedLine;

        /// <summary>
        /// Unexecute command
        /// </summary>
        public override void Unexecute(Model model) => model.SelectedLine = this.oldSelectedLine;

        /// <summary>
        /// Checks if user doing significant actions to use it
        /// </summary>
        public override bool Significant(Model model)
        {
            this.oldSelectedLine = model.SelectedLine;
            this.newSelectedLine = model.FindIntersection(this.point);

            return this.oldSelectedLine != this.newSelectedLine;
        }
    }
}
