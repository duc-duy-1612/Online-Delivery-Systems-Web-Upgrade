using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;
using ĐACN.Models;
using ĐACN.Hubs;
using System.Collections.Generic;

namespace ĐACN.Services
{
    public static class OrderDispatcher
    {
        public static void DispatchOrder(string maDon, string maNH)
        {
            Task.Run(async () => 
            {
                using (var db = new FoodDeliveryDBEntities()) 
                {
                    var don = db.DonHangs.Find(maDon);
                    if (don == null) return;
                    
                    var nhaHang = db.NhaHangs.Find(maNH);
                    if (nhaHang == null) return;

                    double nhLat = nhaHang.Latitude ?? 0;
                    double nhLng = nhaHang.Longitude ?? 0;

                    if (nhLat == 0) return;

                    // Get online shippers from RealTimeLocationService
                    var activeLocations = RealTimeLocationService.GetAllLocations()
                        .Where(l => (DateTime.Now - l.ThoiGianCapNhat).TotalMinutes < 15) // Only recently updated locations
                        .ToList();

                    // Filter only shippers that are in DB and not currently delivering another order
                    var availableShippers = new List<ShipperLocation>();
                    foreach (var loc in activeLocations)
                    {
                        var s = db.Shippers.FirstOrDefault(x => x.MaShipper == loc.MaShipper && x.TaiKhoan.TrangThai == true);
                        if (s != null)
                        {
                            // Check if shipper is free (doesn't have orders that are "Đang lấy món" or "Đang giao")
                            bool isBusy = db.DonHangs.Any(d => d.MaShipper == s.MaShipper && (d.TrangThai == "Đang lấy món" || d.TrangThai == "Đang giao"));
                            if (!isBusy)
                            {
                                availableShippers.Add(loc);
                            }
                        }
                    }

                    // Sort by distance using Haversine
                    var sortedShippers = availableShippers.OrderBy(loc => 
                        CalculateHaversineDistance(nhLat, nhLng, loc.Latitude, loc.Longitude)
                    ).ToList();

                    var context = GlobalHost.ConnectionManager.GetHubContext<DeliveryHub>();

                    bool accepted = false;

                    foreach(var shipperLoc in sortedShippers) 
                    {
                        // Check if order is already accepted
                        var currentDon = db.DonHangs.Find(maDon);
                        if (!string.IsNullOrEmpty(currentDon.MaShipper) || currentDon.TrangThai == "Đã hủy") 
                        {
                            accepted = true;
                            break;
                        }

                        // Ping this specific shipper
                        double dist = CalculateHaversineDistance(nhLat, nhLng, shipperLoc.Latitude, shipperLoc.Longitude);
                        context.Clients.Group("Shipper_" + shipperLoc.MaShipper).pingOrder(maDon, Math.Round(dist, 1));
                        
                        // Wait 15 seconds for shipper to accept
                        await Task.Delay(15000);
                        
                        // Re-fetch order from DB to see if THIS shipper or anyone accepted
                        db.Entry(currentDon).Reload();
                        if (!string.IsNullOrEmpty(currentDon.MaShipper) || currentDon.TrangThai == "Đã hủy")
                        {
                            accepted = true;
                            break;
                        }
                    }

                    // If NO shipper accepted after looping all
                    if (!accepted)
                    {
                         // Broadcast to all shippers as a fallback
                         context.Clients.Group("Shippers").notifyNewOrder($"Có đơn mới cần giao từ nhà hàng {maNH} ({maDon})");
                    }
                }
            });
        }
        
        private static double CalculateHaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
