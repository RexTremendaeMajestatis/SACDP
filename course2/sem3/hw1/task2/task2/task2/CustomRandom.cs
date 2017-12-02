using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Custom random class
    /// </summary>
    public sealed class CustomRandom : ICustomRandom
    {
        int ICustomRandom.Random()
        {
            Random c = new Random();
            return c.Next(100);
        }
    }
}