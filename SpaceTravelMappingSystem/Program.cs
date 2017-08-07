namespace SpaceTravelMappingSystem
{
    using System;
    using System.Threading.Tasks;
    using Autofac;
    using Service;
    using Utility;

    //In order to restore the package dependencies, run paket.bootstrapper.exe inside the .paket folder.
    //The bootstrapper will download the paket.exe file.
    //use the paket install command.
    
    public class Program
    {
        private static IContainer _container;

        private static void Main(string[] args)
        {
            Process().Wait();
        }

        private static async Task Process()
        {
            var filePath = ConfigurationReader.ReadString("filePath");

            _container = DependencyResolver.ResolveDependencies();

            using (var scope = _container.BeginLifetimeScope())
            {
                Console.WriteLine("Starting planet generation");
                var spaceMapGenerator = scope.Resolve<ISpaceMapGenerator>();
                await spaceMapGenerator.GenerateMapAndWriteToFileAsync(filePath);

                var calculator = scope.Resolve<INavigationService>();
                var result = await calculator.GetTravelDetailsAsync(filePath).ConfigureAwait(false);
                Console.WriteLine($"Maximum colonization surface: {result.MaxColonizableSpace} km2" );
                Console.WriteLine("This is the list of the 10 closes inhabitable planets");
                var i = 0;
                result.ClosestPlanets.ForEach(x =>
                {
                    Console.WriteLine($"Planet{i} x={x.X}, y={x.Y}, z={x.Z}, size={x.Size}");
                    i++;
                });
            }
            Console.WriteLine("Hit enter to close the program.");
            Console.ReadLine();
        }
    }
}