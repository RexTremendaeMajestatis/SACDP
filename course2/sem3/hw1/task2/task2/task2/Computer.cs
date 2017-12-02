using System;

namespace Task2
{
    /// <summary>
    /// Computer class
    /// </summary>
    public sealed class Computer
    {
        /// <summary>
        /// Operating system of computer
        /// </summary>
        public string Os { get; }

        /// <summary>
        /// Viral condition of computer
        /// </summary>
        public bool IsInfected { get; set; }

        private const int OsWindows = 70;
        private const int OsLinux = 50;
        private const int OsMac = 40;
        private readonly ICustomRandom Randomizer;
        private static int Defect;

        /// <summary>
        /// Computer class constructor
        /// </summary>
        public Computer(string os, ICustomRandom randomizer)
        {
            Randomizer = randomizer;
            IsInfected = false;
            if (os == "")
            {
                
            }
            Os = os;

            switch (Os)
            {
                case "Windows":
                    Defect = OsWindows;
                    break;
                case "Linux":
                    Defect = OsLinux;
                    break;
                case "MacOs":
                    Defect = OsMac;
                    break;
            }
        }

        /// <summary>
        /// Try to infect the computer
        /// </summary>
        public void TryToInfect()
        {
            int probability = Randomizer.Random();

            if (probability < Defect)
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
