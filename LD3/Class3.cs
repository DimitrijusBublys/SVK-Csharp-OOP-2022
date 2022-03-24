using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    internal class Progression
    {
        // Kintamieji

        public int times = 1;
        public double currentNumber = 1; // Dabartinis numeris (galutinis)
        public double lastNumber = 2; // Praeitas numeris

        public void numberProgression()
        {
            double finalNumber = Math.Pow(10, 15);
            while (currentNumber <= finalNumber)
            {
                double numberPlaceholder = currentNumber;
                currentNumber *= lastNumber;
                times++;
                lastNumber = numberPlaceholder;
            }
        }
    }
}
