namespace Task4.Controller
{
    using Task4.Model;

    abstract class Command
    {
        public abstract void Execute(Model model);

        public abstract void Unexecute(Model model);

        public virtual bool Significant(Model model) => true;
    }
}
