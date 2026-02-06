using System;
using System.Collections.Generic;

namespace Q19
{
    public class DeliveryStatus
    {
        public string TrackingNumber { get; set; }
        public List<string> Checkpoints { get; set; } = new();
        public string CurrentStatus { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public DateTime ActualDelivery { get; set; }
    }
}
