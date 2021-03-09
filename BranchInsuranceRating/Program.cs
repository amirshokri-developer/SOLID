using System;

namespace BranchInsuranceRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Branch Rating System Starting...");

            var engine = new RatingEngine();
            engine.Rate();
            Console.WriteLine($"Rating: {engine.Rating}");

            Console.WriteLine("Please Press A Key ...");
            Console.ReadKey();
        }
    }
}
