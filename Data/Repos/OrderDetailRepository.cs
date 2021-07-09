using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos
{
    public class OrderDetailRepository : BaseRepository<Guid, OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
