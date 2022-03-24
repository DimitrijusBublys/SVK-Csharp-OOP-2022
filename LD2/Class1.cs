using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    internal class Geometry
    {
        // Kintamieji

        public int multiplier = 2; // Daugiklis
        public int startingNumber = 2; // Pradinis numeris
        public int times = 1;
        public double currentNumber;


        public void geometricProgression()
        {
            currentNumber = startingNumber;
            double finalNumber = Math.Pow(10, 15); // 10 pakelta 15 kartų
            while (currentNumber <= finalNumber) // Kol neprieiname iki galutinio numerio (10^15)
            {
                currentNumber *= multiplier;
                times++;
            }
        }
    }
}
