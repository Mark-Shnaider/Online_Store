using System;
using Common.Contracts.Repos.Base;
using Common.Models.Entities;
using Common.Models.Entities.Identity;

namespace Common.Contracts.Repos.Identity
{
    public interface IUserRepository:IBaseRepository<Guid, User>
    {
    }
}
