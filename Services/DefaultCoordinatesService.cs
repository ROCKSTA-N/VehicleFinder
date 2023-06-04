using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFinder.Models;

namespace VehicleFinder.Services
{
    public static class DefaultCoordinatesService
    {
        public static List<Coordinate> GetDefaultCoordinate()
        => new()
        {
            new Coordinate{Lat =34.544909f, Long= -102.100843f},
            new Coordinate{Lat =32.345544f,  Long=-99.123124f},
            new Coordinate{Lat =33.234235f, Long= -100.214124f},
            new Coordinate{Lat =35.195739f,  Long=-95.348899f},
            new Coordinate{Lat =31.895839f,  Long=-97.789573f},
            new Coordinate{Lat =32.895839f, Long= -101.789573f},
            new Coordinate{Lat =34.115839f,  Long=-100.225732f},
            new Coordinate{Lat =32.335839f,  Long=-99.992232f},
            new Coordinate{Lat =33.535339f,  Long=-94.792232f},
            new Coordinate{Lat =32.234235f, Long= -100.222222f},
        };
    }
}
