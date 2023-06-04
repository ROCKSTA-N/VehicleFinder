// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;
using VehicleFinder.Models;
using VehicleFinder.Services;


var defaultCoordinates = DefaultCoordinatesService.GetDefaultCoordinate();

var dataFromFile = DatFIleReader.ReadFileContent("./VehiclePositions.dat");

var positions = ReadVehiclePositions(dataFromFile);

var closestDistance =  double.MaxValue;
var closestVehicles = defaultCoordinates.Select(coordinate =>
{
    var vehicle = ClosestPosition(positions, coordinate);
   
    return vehicle;
}).ToList();


Console.WriteLine("Closest Vehicles");
Console.WriteLine("_________________");

foreach (var closestVehicle in closestVehicles.Where(closestVehicle => closestVehicle != null))
{
    Console.WriteLine(
        $"Vehicle Id : {closestVehicle.Id} - Registration : {closestVehicle.Registration} : Latitude {closestVehicle.Latitude}: Longitude : {closestVehicle.Longitude}");
}
Console.WriteLine("_________________");

Position ClosestPosition(List<Position> vehicles, Coordinate coordinate)
{
    Position location = null;
    foreach (var position in vehicles)
    {
        var distance = DistanceCalculator.CalculateDistance(coordinate, new Coordinate
        {
            Lat = position.Latitude,
            Long = position.Longitude
        });

        if (!(distance < closestDistance)) continue;

        closestDistance = distance;
        location = position;
    }

    return location;
}

static List<Position> ReadVehiclePositions(byte[] data)
{
    var vehicles = new List<Position>();
    using var stream = new MemoryStream(data);

    const int recordSize = sizeof(int) + (sizeof(float) * 2) + sizeof(ulong);

    var numRecords = data.Length / recordSize;
     

    for (var i = 0; i < numRecords; i++)
    {
        var buffer = new byte[20];
        stream.Read(buffer, 0, 20);

        var vehicleId = BitConverter.ToInt32(buffer, 0);
        var registration = Encoding.ASCII.GetString(buffer, 4, 8).Trim('\0');
        var latitude = BitConverter.ToSingle(buffer, 12);
        var longitude = BitConverter.ToSingle(buffer, 16);

        var vehicle = new Position
        {
            Latitude = latitude,
            Longitude = longitude,
            Id = vehicleId,
            Registration = registration
        };

        vehicles.Add(vehicle);
    }

    return vehicles;
}