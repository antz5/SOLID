using System;

namespace SRP1
{
    class Program
    {
        static void Main(string[] args)
        {  

            Console.WriteLine("Insurance Rating system");

            var engine = new RatingEngine();
            engine.Rate();
        }
    }
}
