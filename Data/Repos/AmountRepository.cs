using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos
{
    public class AmountRepository : BaseRepository<Guid, Amount>, IAmountRepository
    {
        public AmountRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
