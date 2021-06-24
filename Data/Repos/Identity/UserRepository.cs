using System;
using Microsoft.EntityFrameworkCore;
using Common.Contracts.Repos.Identity;
using Common.Models.Entities.Identity;
using Data.Repos.Base;

namespace Data.Repos.Identity
{
    public class UserRepository : BaseRepository<Guid, User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
