using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public String OS
        {
            get { return os; }
        }

        /// <summary>
        /// Viral condition of computer
        /// </summary>
        public bool IsInfected
        {
            get { return isInfected; }
        }
        private static double osWindows = 0.7;
        private static double osLinux = 0.1;
        private static double osMacOS = 0.2;
        private static double defect;
        private String os;
        
        private bool isInfected;


        /// <summary>
        /// Initialize new computer object
        /// </summary>
        /// <param name="os"></param>
        public Computer(String os)
        {
            isInfected = false;
            this.os = os;

            if (this.os == "Windows")
            {
                defect = osWindows;
            }
            if (this.os == "Linux")
            {
                defect = osLinux;
            }
            if (this.os == "MacOS")
            {
                defect = osMacOS;
            }
        }

        /// <summary>
        /// Try to infect the computer
        /// </summary>
        public void TryToInfect()
        {
            Random rand = new Random();
            double probability = rand.Next(100) / 100;
            if (probability < defect)
            {
                isInfected = true;
            }
        }

        /// <summary>
        /// Infect the computer
        /// </summary>
        public void Infect()
        {
            isInfected = true;
        }
    }
}
