using System;
using System.Collections.Generic;
using System.Linq;

namespace Q19
{
    public class CourierManager
    {
        private readonly List<Package> _packages = new();
        private readonly List<DeliveryStatus> _statuses = new();

        public void AddPackage(string sender, string receiver, string address,
                               double weight, string type, double cost)
        {
            var trackingNumber = Guid.NewGuid().ToString();

            _packages.Add(new Package
            {
                TrackingNumber = trackingNumber,
                SenderName = sender,
                ReceiverName = receiver,
                DestinationAddress = address,
                Weight = weight,
                PackageType = type,
                ShippingCost = cost
            });

            _statuses.Add(new DeliveryStatus
            {
                TrackingNumber = trackingNumber,
                CurrentStatus = "Dispatched",
                EstimatedDelivery = DateTime.Now.AddDays(3),
                ActualDelivery = DateTime.MinValue
            });
        }

        public bool UpdateStatus(string trackingNumber, string status, string checkpoint)
        {
            var packageStatus = _statuses.FirstOrDefault(s => s.TrackingNumber == trackingNumber);
            if (packageStatus == null)
                return false;

            packageStatus.CurrentStatus = status;
            packageStatus.Checkpoints.Add($"{DateTime.Now}: {checkpoint}");

            if (status == "Delivered")
                packageStatus.ActualDelivery = DateTime.Now;

            return true;
        }

        public Dictionary<string, List<Package>> GroupPackagesByType()
        {
            return _packages
                .GroupBy(p => p.PackageType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Package> GetPackagesByDestination(string city)
        {
            return _packages
                .Where(p => p.DestinationAddress.Contains(city, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Package> GetDelayedPackages()
        {
            return _statuses
                .Where(s => s.CurrentStatus != "Delivered" && DateTime.Now > s.EstimatedDelivery)
                .Join(_packages,
                      s => s.TrackingNumber,
                      p => p.TrackingNumber,
                      (s, p) => p)
                .ToList();
        }
    }
}
