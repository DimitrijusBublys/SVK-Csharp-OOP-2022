using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    internal class Factorial
    {
        // Kintamieji

        public int startingNumber = 5; // Pradinis numeris
        public int times = 0; // Ciklo sukimosi kartai
        public int currentNumber; // Galutinis numeris

        public Factorial()
        {
            currentNumber = startingNumber;
            for (int i = startingNumber - 1; i > 0; i--) // 22 eil
            {
                currentNumber *= i; // currentNumber = 5; i = 4 ; 5*5-1 * 4-1 * 3 -1
                times++;
            }
        }
    }
}
