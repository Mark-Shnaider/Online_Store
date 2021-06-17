﻿using System;
using Common.Contracts.Repos.Base;
using Common.Models.Entities;

namespace Common.Contracts.Repos
{
    public interface IAmountRepository:IBaseRepository<Guid, Amount>
    {
    }
}
