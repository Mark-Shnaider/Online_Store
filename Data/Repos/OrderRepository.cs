using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos
{
    public class OrderRepository : BaseRepository<Guid, Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
