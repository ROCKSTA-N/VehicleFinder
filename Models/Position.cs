using System;

namespace VehicleFinder.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime RecordedTimeUTC { get; set; }
    }
}