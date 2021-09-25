using System;
using System.Collections.Generic;

namespace Logixboard.API.Models
{
    public class Shipment
    {
        public String ReferenceId { get; init; }

        public IList<Organization> Organizations { get; init; }

        public IList<Node> TransportPacks { get; set; }

        public DateTime EstimatedTimeArrival { get; init; }
    }
}