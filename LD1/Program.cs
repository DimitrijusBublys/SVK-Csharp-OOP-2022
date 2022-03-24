using System;

namespace Geometry
{
    internal class Output
    {
        // Geometrinės progresijos kintamieji

        public int multiplier = 2; // Daugiklis
        public int startingNumber = 2; // Pradinis numeris
        public int times = 1; // Ciklo sukimosi kartai
        public double currentNumber; // Galutinis numeris

        // Matematinės progesijos kintamieji

        public int times2 = 1; // Ciklo sukimosi kartai
        public double currentNumber2 = 1; // Dabartinis (galutinis) numeris
        public double lastNumber2 = 2; // Praeitas numeris matematinėje sekoje
        static void Main(string[] args)
        {
            double finalNumber = Math.Pow(10, 15);
            Output obj = new();
            obj.currentNumber = obj.startingNumber;
            while (obj.currentNumber <= finalNumber) // Geometrinė progresija
            {
                obj.currentNumber *= obj.multiplier;
                obj.times++;
            }

            while (obj.currentNumber2 <= finalNumber) // Matematinė progresija
            {
                double numberPlaceholder = obj.currentNumber2;
                obj.currentNumber2 *= obj.lastNumber2;
                obj.times2++;
                obj.lastNumber2 = numberPlaceholder;
            }

            // Išvedimas

            Console.WriteLine("Geometrinė progresija");
            Console.WriteLine("Galutinis skaičius: " + obj.currentNumber + System.Environment.NewLine + "Ciklo sukimosi kartai: " + obj.times);

            Console.WriteLine("--------------------");

            Console.WriteLine("Matematinė progresija");
            Console.WriteLine("Galutinis skaičius: " + obj.currentNumber2 + System.Environment.NewLine + "Ciklo sukimosi kartai: " + obj.times2);

        }
    }
}