using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using Business.Models;
using DataAccess.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public interface ICityService : IServices<CityModel>
    {

    }


    public class CityService : ICityService
    {
        private readonly CityRepositoryBase _cityReposityBase;
        public CityService(CityRepositoryBase cityReposityBase)
        {
            _cityReposityBase = cityReposityBase;
        }
        public Result Add(CityModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _cityReposityBase.Dispose();
        }

        public IQueryable<CityModel> GetQuery()
        {
            return _cityReposityBase.GetEntityQuery("Country").OrderBy(c => c.Name).Select(c => new CityModel()
            {
                Id = c.Id,
                Guid = c.Guid,
                Name = c.Name,
                CountryId = c.CountryId,
                Country = new CountryModel()
                {
                    Id = c.Country.Id,
                    Guid = c.Country.Guid,
                    Name = c.Country.Name
                }
            });
        }

        public Result Update(CityModel model)
        {
            throw new NotImplementedException();
        }
    }
}
