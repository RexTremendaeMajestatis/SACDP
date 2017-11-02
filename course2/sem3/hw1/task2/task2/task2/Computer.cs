using System;

namespace task2
{
    /// <summary>
    /// Computer class
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// Operating system of computer
        /// </summary>
        public String OS { get; }

        /// <summary>
        /// Viral condition of computer
        /// </summary>
        public bool IsInfected { get; set; }

        private static readonly int osWindows = 70;
        private static readonly int osLinux = 50;
        private static readonly int osMacOS = 40;
        private ICustomRandom randomizer;
        private static int _defect;

        /// <summary>
        /// Initialize new computer object
        /// </summary>
        /// <param name="os"></param>
        public Computer(String os, ICustomRandom randomizer)
        {
            this.randomizer = randomizer;
            IsInfected = false;
            if (os == "")
            {
                throw new Exception(message: "Empty string");
            }
            OS = os;

            if (OS == "Windows")
            {
                _defect = osWindows;
            }
            if (OS == "Linux")
            {
                _defect = osLinux;
            }
            if (OS == "MacOS")
            {
                _defect = osMacOS;
            }


        }
        /// <summary>
        /// Try to infect the computer
        /// </summary>
        public void TryToInfect()
        {
            int probability = randomizer.Random();
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
