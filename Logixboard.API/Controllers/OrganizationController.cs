using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logixboard.API.DTOs;
using Logixboard.API.Repositories;
using Logixboard.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Logixboard.API.Controllers
{
    [ApiController]
    [Route("organization")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        // GET /organization/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationDTO>> GetOrganizationAsync(String id)
        {
            var organization = (await _organizationRepository.GetByIdAsync(id));

            if(organization is null) return NotFound();

            OrganizationDTO organizationDTO = new OrganizationDTO(){
                Id = organization.Id,
                Code = organization.Code
            };

            return organizationDTO;
        }

        // POST /organization
        [HttpPost]
        public async Task<ActionResult<OrganizationDTO>> CreateOrganization(OrganizationDTO organization)
        {
            Organization newOrganiztion = new Organization(){
                Id = organization.Id,
                Code = organization.Code
            };

            await _organizationRepository.CreateOrUpdateAsync(newOrganiztion);

            return CreatedAtAction(nameof(GetOrganizationAsync), new { id = newOrganiztion.Id }, newOrganiztion);
        }
    }
}