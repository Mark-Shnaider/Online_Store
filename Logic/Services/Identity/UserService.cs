using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Common.Models.DTO;
using Common.Models.Entities;
using Common.Contracts;
using Common.Contracts.Services;
using Logic.Services.Base;
using Logic.Services.Identity;
using Common.Contracts.Services.Identity;
using Common.Models.DTO.Identity;
using Common.Models.Entities.Identity;

namespace Logic.Services.Identity
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
            : base(mapper, serviceProvider, unitOfWork)
        {

        }
        public void CreateUser(UserDto userDTO)
        {
            if (userDTO == null)
                return;
            userDTO.Id = Guid.NewGuid();
            User user = _mapper.Map<User>(userDTO);
            _unitOfWork.Users.Add(user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(UserDto userDTO)
        {
            if (userDTO == null)
            {
                return;
            }

            User user = _mapper.Map<User>(userDTO);
            _unitOfWork.Users.Delete(user);
            _unitOfWork.Commit();
        }

        public UserDto GetUser(Guid Id)
        {
            User user = _unitOfWork.Users.GetById(Id);
            if (user == null)
                return null;
            return _mapper.Map<UserDto>(user);
        }

        public void UpdateUser(UserDto userDTO)
        {
            if (userDTO == null)
                return;

            User user = _mapper.Map<User>(userDTO);
            _unitOfWork.Users.AddOrUpdate(user);
            _unitOfWork.Commit();
        }
    }
}
