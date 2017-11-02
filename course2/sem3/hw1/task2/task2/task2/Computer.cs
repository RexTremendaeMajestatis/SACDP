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
        /// <summary>
        /// Custom randomizer for testing ability
        /// </summary>
        private ICustomRandom randomizer;
        private static int defect;

        /// <summary>
        /// Computer class constructor
        /// </summary>
        /// <param name="os"></param>
        /// <param name="randomizer"></param>
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
                defect = osWindows;
            }
            if (OS == "Linux")
            {
                defect = osLinux;
            }
            if (OS == "MacOS")
            {
                defect = osMacOS;
            }


        }
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
