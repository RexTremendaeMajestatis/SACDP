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

        private static readonly double osWindows = 0.7;
        private static readonly double osLinux = 0.5;
        private static readonly double osMacOS = 0.4;
        private static double _defect;

        /// <summary>
        /// Initialize new computer object
        /// </summary>
        /// <param name="os"></param>
        public Computer(String os)
        {
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
            Random rand = new Random();
            double probability = rand.Next(100);
            probability /= 100;
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
