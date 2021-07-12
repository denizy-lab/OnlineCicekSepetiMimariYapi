using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using Business.Enums;
using Business.Models;
using DataAccess.EntityFramework.Repositories;
using Entities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public interface IUserService : IServices<UserModel>
    {

    }
    public class UserService : IUserService
    {
        private readonly UserRepositoryBase _userRepository;
        public UserService(UserRepositoryBase userRepository)
        {
            _userRepository = userRepository;
        }
        public Result Add(UserModel model)
        {
            try
            {
                if (_userRepository.GetEntityQuery().Any(u => u.UserName.ToUpper() == model.UserName.ToUpper().Trim()))
                    return new ErrorResult("User with the same user name exists!");
                if (_userRepository.GetEntityQuery("UserDetail").Any(u => u.UserDetail.EMail.ToUpper() == model.UserDetail.EMail.ToUpper().Trim()))
                    return new ErrorResult("User with the same e-mail exists!");
                var entity = new User()
                {
                    active = true,
                    UserName = model.UserName.Trim(),
                    Password = model.Password.Trim(),
                    RoleId = (int)Roles.User,
                    UserDetail = new UserDetail()
                    {
                        Address = model.UserDetail.Address.Trim(),
                        CityId = model.UserDetail.CityId,
                        CountryId = model.UserDetail.CountryId,
                        EMail = model.UserDetail.EMail.Trim()
                    }
                };
                _userRepository.Add(entity);
                return new SuccesResult();

            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> GetQuery()
        {
            throw new NotImplementedException();
        }

        public Result Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
