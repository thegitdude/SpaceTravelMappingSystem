namespace SpaceTravelMappingSystem.Model
{
    public class Planet
    {
        public Planet(int x, int y, int z, PlanetType type, int size)
        {
            X = x;
            Y = y;
            Z = z;
            Type = type;
            Size = size;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public PlanetType Type { get; }

        public int Size { get; }
    }
}
