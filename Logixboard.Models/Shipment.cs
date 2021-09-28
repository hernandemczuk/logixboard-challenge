using System;
using System.Collections.Generic;

namespace Logixboard.Models
{
    public class Shipment
    {
        public String ReferenceId { get; set; }

        public List<Organization> Organizations { get; set; }

        public List<Node> TransportPacks { get; set; }

        public DateTime? EstimatedTimeArrival { get; set; }
    }
}