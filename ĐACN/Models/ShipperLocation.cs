using System;
using System.Collections.Concurrent;

namespace ĐACN.Models
{
    public class ShipperLocation
    {
        public string MaShipper { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
    }

    public static class RealTimeLocationService
    {
        private static readonly ConcurrentDictionary<string, ShipperLocation> locations =
            new ConcurrentDictionary<string, ShipperLocation>();

        public static ShipperLocation GetLocation(string maShipper)
        {
            locations.TryGetValue(maShipper, out var location);
            return location;
        }

        public static void UpdateLocation(string maShipper, double latitude, double longitude)
        {
            var newLocation = new ShipperLocation
            {
                MaShipper = maShipper,
                Latitude = latitude,
                Longitude = longitude,
                ThoiGianCapNhat = DateTime.Now
            };

            locations.AddOrUpdate(maShipper, newLocation, (key, existingVal) => newLocation);
        }

        public static void ClearLocation(string maShipper)
        {
            locations.TryRemove(maShipper, out _);
        }

        public static System.Collections.Generic.IEnumerable<ShipperLocation> GetAllLocations()
        {
            return locations.Values;
        }
    }
}