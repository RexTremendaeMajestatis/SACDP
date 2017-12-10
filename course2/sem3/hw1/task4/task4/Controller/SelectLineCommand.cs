namespace Task4.Controller
{
    using System.Drawing;
    using Task4.Model;

    public sealed class SelectLineCommand : Command
    {
        private Point point;
        private Line newSelectedLine;
        private Line oldSelectedLine;

        public SelectLineCommand(Point point) => this.point = point;

        public override void Execute(Model model) => model.SelectedLine = this.newSelectedLine;

        public override void Unexecute(Model model) => model.SelectedLine = this.oldSelectedLine;

        public override bool Significant(Model model)
        {
            this.oldSelectedLine = model.SelectedLine;
            this.newSelectedLine = model.FindIntersection(point);

            return (this.oldSelectedLine != this.newSelectedLine);
        }
    }
}
