using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logixboard.Models;

namespace Logixboard.API.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Organization> GetByIdAsync(String id);

        Task<Organization> GetByCodeAsync(String code);

        Task CreateOrUpdateAsync(Organization organization);
    }
}
