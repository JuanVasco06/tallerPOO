using System;

namespace Exercise28
{
    public class Application
    {
        public void Run()
        {
            Console.Write("Ingrese la viga: ");
            string input = Console.ReadLine();

            Beam beam = new Beam(input);
            BeamStatus result = beam.Evaluate();

            switch (result)
            {
                case BeamStatus.SupportsWeight:
                    Console.WriteLine("La viga soporta el peso!");
                    break;

                case BeamStatus.DoesNotSupportWeight:
                    Console.WriteLine("La viga NO soporta el peso!");
                    break;

                case BeamStatus.Malformed:
                    Console.WriteLine("La viga está mal construida!");
                    break;
            }
        }
    }
}