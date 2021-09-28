
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logixboard.Database;
using Logixboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Logixboard.API.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shipment> GetByIdAsync(String id)
        {
            return await _context.Shipments
                .Where(x => x.ReferenceId == id)
                .Include(y => y.Organizations)
                .Include(r => r.TransportPacks)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Node>> GetNodesAsync()
        {
            return await _context.Nodes.ToListAsync();
        }

        public async Task CreateOrUpdateAsync(Shipment shipment)
        {
            var existingShipment = await _context.Shipments
                .FindAsync(shipment.ReferenceId);

            if (existingShipment != null){
                _context.Shipments.Remove(existingShipment);
            }

            await _context.SaveChangesAsync();

            foreach(var node in shipment.TransportPacks){
                node.NodeId = Guid.NewGuid().ToString();
            }

            await _context.Shipments.AddAsync(shipment);

            await _context.SaveChangesAsync();
        }
    }
}