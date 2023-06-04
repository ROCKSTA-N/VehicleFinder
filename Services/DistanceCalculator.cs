using VehicleFinder.Models;

namespace VehicleFinder.Services;

public static class DistanceCalculator
{
    public static double CalculateDistance(Coordinate coordinate, Coordinate vehicleLocation)
    {
        double earthRadius = 6371;

        var dLat = ToRadians(vehicleLocation.Lat - coordinate.Lat);
        var dLon = ToRadians(vehicleLocation.Long - coordinate.Long);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(coordinate.Lat)) * Math.Cos(ToRadians(vehicleLocation.Lat)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        var distance = earthRadius * c;

        return distance;
    }

    public static float ToRadians(float degrees)
    {
        return (float)(degrees * Math.PI / 180);
    }
}