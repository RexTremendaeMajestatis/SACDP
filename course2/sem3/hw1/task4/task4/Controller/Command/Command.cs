namespace Task4
{
    /// <summary>
    /// Parent class for commands
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Execute command
        /// </summary>
        public abstract void Execute(Model model);

        /// <summary>
        /// Unexecute command
        /// </summary>
        public abstract void Unexecute(Model model);

        /// <summary>
        /// Checks if significant actions were invoked
        /// </summary>
        public virtual bool Significant(Model model) => true;
    }
}
