using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos
{
    public class ProductRepository : BaseRepository<Guid, Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
