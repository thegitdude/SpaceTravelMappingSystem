using System;
using Autofac;
using SpaceTravelMappingSystem.Service;
using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;
using System.Threading.Tasks;

namespace SpaceTravelMappingSystem
{
    using System.Configuration;
    using Repository;
    using Utility;

    public class Program
    {
        private static IContainer Container;

        static void Main(string[] args)
        {
            Process().Wait();
        }

        static async Task Process()
        {
            var filePath = ConfigurationReader.ReadString("filePath");

            Container = DependencyResolver.ResolveDependencies();

            using (var scope = Container.BeginLifetimeScope())
            {
                Console.WriteLine("Starting planet generation");
                var spaceMapGenerator = scope.Resolve<ISpaceMapGenerator>();
                await spaceMapGenerator.GenerateMapAndWriteToFileAsync(filePath);

                var calculator = scope.Resolve<IFileInteractionRepository>();
                var result = await calculator.ReadFromFileAsync(filePath);
                Console.WriteLine("Number of Planets retrieved: " + result.Count);
            }

            Console.ReadLine();
        }
    }
}
