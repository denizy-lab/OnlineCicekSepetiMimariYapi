using AppCore.DataAccess.EntityFramework.Bases;
using Entities.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public abstract class CityRepositoryBase : RepositoryBase<City>

    {
        protected CityRepositoryBase(DbContext db) : base(db)
        {

        }
        
    }
    public class CityReposity : CountryRepositoryBase
    {
        public CityReposity(DbContext db) : base(db)
        {

        }
    }
}
