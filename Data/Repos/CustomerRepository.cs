using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos
{
    public class CustomerRepository : BaseRepository<Guid, Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
