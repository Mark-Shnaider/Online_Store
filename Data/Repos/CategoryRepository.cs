using System;
using Microsoft.EntityFrameworkCore;
using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;

namespace Data.Repos
{
    public class CategoryRepository : BaseRepository<Guid, Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
