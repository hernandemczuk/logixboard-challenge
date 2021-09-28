using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logixboard.Models;

namespace Logixboard.API.Repositories
{
    public interface IShipmentRepository
    {
        Task<Shipment> GetByIdAsync(String id);
        Task<List<Node>> GetNodesAsync();
        Task CreateOrUpdateAsync(Shipment shipment);
    }
}
