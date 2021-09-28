using System;
using System.Collections.Generic;

namespace Logixboard.API.DTOs
{
    public class ShipmentDTO
    {
        public String ReferenceId { get; set; }

        public List<string> Organizations { get; set; }

        public TransportPackDTO TransportPacks { get; set; }

        public DateTime? EstimatedTimeArrival { get; set; }
    }
}