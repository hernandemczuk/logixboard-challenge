using System;
using System.Collections.Generic;

namespace Logixboard.Models
{
    public class Organization
    {
        public String Id { get; set; }

        public String Code { get; set; }

        public List<Shipment> Shipments { get; set; }
    }
}