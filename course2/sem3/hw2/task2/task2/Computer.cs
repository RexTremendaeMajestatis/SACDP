using System;

namespace Task2
{
    /// <summary>
    /// Computer class
    /// </summary>
    public sealed class Computer
    {
        private const int OsWindows = 70;
        private const int OsLinux = 50;
        private const int OsMac = 40;
        private static int defect;
        private readonly ICustomRandom randomizer;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class
        /// </summary>
        /// <param name="os">OS of the computer</param>
        /// <param name="randomizer">Randomizer that sets chance of infection</param>
        public Computer(string os, ICustomRandom randomizer)
        {
            this.randomizer = randomizer;
            IsInfected = false;
            if (os == string.Empty)
            {
                throw new System.ArgumentException("String can not be empty");
            }
            Os = os;

            switch (Os)
            {
                case "Windows":
                    defect = OsWindows;
                    break;
                case "Linux":
                    defect = OsLinux;
                    break;
                case "MacOs":
                    defect = OsMac;
                    break;
            }
        }

        /// <summary>
        /// Operating system of computer
        /// </summary>
        public string Os { get; }

        /// <summary>
        /// Viral condition of computer
        /// </summary>
        public bool IsInfected { get; set; }

        /// <summary>
        /// Try to infect the computer
        /// </summary>
        public void TryToInfect()
        {
            int probability = randomizer.Random();

            if (probability < defect)
            {
                IsInfected = true;
            }
        }

        /// <summary>
        /// Infect the computer
        /// </summary>
        public void Infect()
        {
            IsInfected = true;
        }
    }
}
