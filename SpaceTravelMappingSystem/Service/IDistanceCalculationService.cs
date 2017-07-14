using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTravelMappingSystem.Service
{
    public interface IDistanceCalculationService
    {
        double GetDistanceToHomePlanet(int x, int y, int z);
    }
}
