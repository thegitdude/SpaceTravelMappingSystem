using Autofac;
using SpaceTravelMappingSystem.Service;

namespace SpaceTravelMappingSystem
{
    public class DependencyResolver
    {
        public static IContainer ResolveDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DistanceCalculationService>().As<IDistanceCalculationService>();
            builder.RegisterType<PlanetGeneratingService>().As<IPlanetGeneratingService>();
            builder.RegisterType<FileInteractionService>().As<IFileInteractionService>();
            builder.RegisterType<SpaceMapGenerator>().As<ISpaceMapGenerator>();

            return builder.Build();
        }
    }
}
