using System;

namespace Task2
{
    /// <summary>
    /// Custom random class
    /// </summary>
    public sealed class CustomRandom : ICustomRandom
    {
        int ICustomRandom.Random()
        {
            Random rand = new Random();
            return rand.Next(100);
        }
    }
}