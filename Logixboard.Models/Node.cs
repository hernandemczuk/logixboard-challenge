using System;
using System.Collections.Generic;

namespace Logixboard.Models
{
    public class Node
    {
        public String NodeId { get; set; }

        public decimal Weight { get; set; }

        public Unit Unit { get; set; }

        public Shipment Shipment { get; set; }
    }
}