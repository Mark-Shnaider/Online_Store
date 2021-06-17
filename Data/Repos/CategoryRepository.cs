using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos
{
    public class CategoryRepository : BaseRepository<Guid, Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
