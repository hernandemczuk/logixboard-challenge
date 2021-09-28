
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Logixboard.Database;
using Logixboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Logixboard.API.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Organization> GetByIdAsync(String id)
        {
            return await _context.Organizations.FindAsync(id);
        }

        public async Task<Organization> GetByCodeAsync(String code)
        {
            return await _context.Organizations.Where(x => x.Code == code).SingleOrDefaultAsync();
        }

        public async Task CreateOrUpdateAsync(Organization organization)
        {
            var existingOrganization = _context.Organizations.Find(organization.Id);

            if (existingOrganization == null){
                _context.Organizations.Add(organization);
            }
            else {
                existingOrganization.Code = organization.Code;
            }

            await _context.SaveChangesAsync();
        }
    }
}