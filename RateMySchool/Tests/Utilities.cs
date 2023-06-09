using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Utilities
    {
        public static float GenerateRandomFloat(int min, int max)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * max) + min;
        }
    }
}
