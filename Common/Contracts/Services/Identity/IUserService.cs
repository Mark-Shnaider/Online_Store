using System;
using System.Collections.Generic;
using Common.Contracts.Services.Base;
using Common.Models.DTO.Identity;


namespace Common.Contracts.Services.Identity
{
    public interface IUserService:IService
    {
        public void CreateUser(UserDto user);
        public UserDto GetUser(Guid Id);
        public void UpdateUser(UserDto user);
        public void DeleteUser(UserDto user);
    }
}
