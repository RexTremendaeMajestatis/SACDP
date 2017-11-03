using System;

namespace task2
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
        /// <param name="os"></param>
        /// <param name="randomizer"></param>
        public Computer(string os, ICustomRandom randomizer)
        {
            _randomizer = randomizer;
            IsInfected = false;
            if (os == "")
            {
                throw new Exception(message: "Empty string");
            }
            Os = os;

            if (Os == "Windows")
            {
                _defect = OsWindows;
            }
            if (Os == "Linux")
            {
                _defect = OsLinux;
            }
            if (Os == "MacOS")
            {
                _defect = OsMac;
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
