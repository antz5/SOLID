using System;

using Microsoft.Extensions.DependencyInjection;
using OCPAfter.JSONCommonConverter;
using OCPAfter.Logger;
using OCPAfter.Persistence;

namespace OCPAfter
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
            .AddTransient<ILogging, Logging>()
            .AddTransient<IFilePersistence,FilePersistence>()
            .AddTransient<IJsonCommonConverter<Policy>,JsonCommonConverter<Policy>>()
            .BuildServiceProvider();

            Console.WriteLine("Insurance Rating system");

            var engine = new RatingEngine(new Logging(), new FilePersistence(), new JsonCommonConverter<Policy>());
            engine.Rate();
        
        }
    }
}
