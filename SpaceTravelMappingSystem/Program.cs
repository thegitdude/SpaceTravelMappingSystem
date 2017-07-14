using System;
using Autofac;
using SpaceTravelMappingSystem.Service;
using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;
using System.Threading.Tasks;

namespace SpaceTravelMappingSystem
{
    public class Program
    {
        private static IContainer Container;

        static void Main(string[] args)
        {
            Process().Wait();
        }

        static async Task Process()
        {
            Container = DependencyResolver.ResolveDependencies();

            using (var scope = Container.BeginLifetimeScope())
            {
                Console.WriteLine("Starting planet generation");
                var spaceMapGenerator = scope.Resolve<ISpaceMapGenerator>();
                await spaceMapGenerator.GenerateMapAndWriteToFileAsync();

                var calculator = scope.Resolve<IFileInteractionService>();
                var result = await calculator.ReadFromFileAsync<List<Planet>>("C:\\temp\\map.txt");
                Console.WriteLine("Number of Planets retrieved: " + result.Count);
            }

            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }
}
