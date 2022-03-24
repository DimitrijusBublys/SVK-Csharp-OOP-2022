using System;

namespace Geometry
{
    internal class Output
    {

        static void Main(string[] args)
        {
            Factorial obj = new Factorial();

            Console.WriteLine("Faktorialas");
            Console.WriteLine("Pradinis skaičius: " + obj.startingNumber + System.Environment.NewLine + "Galutinis skaičius: " +
                obj.currentNumber + System.Environment.NewLine + "Ciklo sukimosi kartai: " + obj.times);


            Console.WriteLine("------------------");

            Geometry obj2 = new Geometry();
            obj2.geometricProgression();

            Console.WriteLine("Geometrinė progresija");
            Console.WriteLine("Galutinis skaičius: " + obj2.currentNumber + System.Environment.NewLine + "Ciklo sukimosi kartai: " + obj2.times);

            Console.WriteLine("------------------");

            Progression obj3 = new Progression();
            obj3.numberProgression();

            Console.WriteLine("Matematinė progresija");
            Console.WriteLine("Galutinis skaičius: " + obj3.currentNumber + System.Environment.NewLine + "Ciklo sukimosi kartai: " + obj3.times);
        }
    }
}