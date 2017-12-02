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
        private readonly ICustomRandom _randomizer;
        private static int _defect;

        /// <summary>
        /// Computer class constructor
        /// </summary>
        public Computer(string os, ICustomRandom randomizer)
        {
            _randomizer = randomizer;
            IsInfected = false;
            if (os == "")
            {
                
            }
            Os = os;

            switch (Os)
            {
                case "Windows":
                    _defect = OsWindows;
                    break;
                case "Linux":
                    _defect = OsLinux;
                    break;
                case "MacOs":
                    _defect = OsMac;
                    break;
            }
        }

        /// <summary>
        /// Try to infect the computer
        /// </summary>
        public void TryToInfect()
        {
            int probability = _randomizer.Random();

            if (probability < _defect)
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
