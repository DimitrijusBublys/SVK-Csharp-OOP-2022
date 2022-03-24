using System;

namespace Geometry
{
    internal class Output
    {

        static void Main(string[] args)
        {
            Geometry obj = new Geometry();
            obj.geometricProgression();
            Console.WriteLine("Geometrinė progresija");
            Console.WriteLine("Galutinis skaičius: " + obj.currentNumber + System.Environment.NewLine + "Ciklo sukimosi kartai: " + obj.times);

            Console.WriteLine("------------------");

            Progression obj2 = new Progression();
            obj2.numberProgression();
            Console.WriteLine("Matematinė progresija");
            Console.WriteLine("Galutinis skaičius: " + obj2.currentNumber + System.Environment.NewLine + "Ciklo sukimosi kartai: " + obj2.times);
        }
    }
}