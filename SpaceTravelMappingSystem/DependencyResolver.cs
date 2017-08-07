using Autofac;
using SpaceTravelMappingSystem.Service;

namespace SpaceTravelMappingSystem
{
    using Repository;

    public class DependencyResolver
    {
        public static IContainer ResolveDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<DistanceCalculationService>().As<IDistanceCalculationService>();
            builder.RegisterType<PlanetGeneratingService>().As<IPlanetGeneratingService>();
            builder.RegisterType<FileInteractionRepository>().As<IFileInteractionRepository>();
            builder.RegisterType<SpaceMapGenerator>().As<ISpaceMapGenerator>();

            return builder.Build();
        }
    }
}
