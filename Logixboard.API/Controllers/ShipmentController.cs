using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logixboard.API.DTOs;
using Logixboard.API.Extensions;
using Logixboard.API.Repositories;
using Logixboard.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Logixboard.API.Controllers
{
    [ApiController]
    [Route("shipment")]
    public class ShipmentController : Controller
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public ShipmentController(IShipmentRepository shipmentRepository, IOrganizationRepository organizationRepository)
        {
            _shipmentRepository = shipmentRepository;
            _organizationRepository = organizationRepository;
        }

        //GET /shipment/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentDTO>> GetShipmentAsync(String id)
        {
            var shipment = (await _shipmentRepository.GetByIdAsync(id));

            if(shipment is null) return NotFound();

            ShipmentDTO shipmentDto = new ShipmentDTO(){
                EstimatedTimeArrival = shipment.EstimatedTimeArrival,
                ReferenceId = shipment.ReferenceId,
                Organizations = new List<string>(),
                TransportPacks = new TransportPackDTO() {
                    Nodes = new List<NodeDTO>()
                }
            };

            foreach(var organization in shipment.Organizations){
                shipmentDto.Organizations.Add(organization.Code);
            }

            foreach(var node in shipment.TransportPacks){
                shipmentDto.TransportPacks.Nodes.Add(new NodeDTO(){ 
                    TotalWeight = new TotalWeightDTO(){
                        Weight = node.Weight,
                        Unit = node.Unit.ToString()
                    }
                });
            }

            return shipmentDto;
        }

        //GET /shipment/:id
        [HttpGet("totalWeight/{unit}")]
        public async Task<ActionResult<decimal>> GetShipmentsTotalWeight(String unit)
        {
            decimal totalWeight = 0;

            var nodes = (await _shipmentRepository.GetNodesAsync());

            foreach(var enumUnit in Enum.GetValues(typeof(Unit))){
                var listOfWeights = nodes.Where(x => x.Unit == (Unit) Enum.Parse(typeof(Unit), enumUnit.ToString()))
                                         .Select(x => x.Weight);
                foreach(var weight in listOfWeights){
                    totalWeight += UnitConverters.Convert(weight, (Unit) Enum.Parse(typeof(Unit), enumUnit.ToString()), (Unit) Enum.Parse(typeof(Unit), unit.ToString()));
                }
            }
            return totalWeight;
        }

        //POST /shipment
        [HttpPost]
        public async Task<ActionResult<Shipment>> CreateShipment(ShipmentDTO shipment)
        {
            Shipment newShipment = new Shipment(){
                EstimatedTimeArrival = shipment.EstimatedTimeArrival,
                ReferenceId = shipment.ReferenceId,
                Organizations = new List<Organization>(),
                TransportPacks = new List<Node>()
            };

            foreach(var organization in shipment.Organizations){
                var existingOrganization = await _organizationRepository.GetByCodeAsync(organization);
                newShipment.Organizations.Add(existingOrganization);
            }

            foreach(var transportPack in shipment.TransportPacks.Nodes){
                newShipment.TransportPacks.Add(new Models.Node(){ 
                    Weight = transportPack.TotalWeight.Weight, 
                    Unit = (Unit)Enum.Parse(typeof(Unit), transportPack.TotalWeight.Unit)
                });
            }

            await _shipmentRepository.CreateOrUpdateAsync(newShipment);

            return CreatedAtAction(nameof(GetShipmentAsync), new { id = newShipment.ReferenceId }, shipment);
        }
    }
}