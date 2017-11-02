﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    /// <summary>
    /// Interface for custom random
    /// </summary>
    public interface ICustomRandom
    {
        int Random();
    }
    /// <summary>
    /// Custom random class
    /// </summary>
    internal class CustomRandom: ICustomRandom
    {
        int ICustomRandom.Random()
        {
            Random c = new Random();
            return c.Next(100);
        }
    }
}