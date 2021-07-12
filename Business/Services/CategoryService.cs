using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Repositories.Bases;
using Entities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepositoryBase _categoryRepository;

        public CategoryService(CategoryRepositoryBase categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        public Result Add(CategoryModel model)
        {
            try
            {
                if (_categoryRepository.GetEntityQuery().Any(c => c.Name.ToUpper() == model.Name.ToUpper().Trim()))
                {
                    return new ErrorResult("Category with the same name exists!");
                }
                var entity = new Category()
                {
                    Description = model.Description?.Trim(),
                    Name = model.Name.Trim()
                };
                _categoryRepository.Add(entity);
                return new SuccesResult();
            }
            catch (Exception e)
            {

               return new ExceptionResult(e);
            }
        }

        public Result Delete(int id)
        {
            try
            {
                var category = _categoryRepository.GetEntityQuery(c => c.Id == id,"Products").SingleOrDefault();
                if(category.Products !=null && category.Products.Count > 0)
                {
                    return new ErrorResult("Category has product so it can't deleted!");
                }
                _categoryRepository.Delete(category);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }

        public IQueryable<CategoryModel> GetQuery()
        {
           
                var query = _categoryRepository.GetEntityQuery("Products").OrderBy(c => c.Name).Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Guid = c.Guid,
                    ProductCount = c.Products.Count
                    
                    
                });
                return query;

           
        }

        public Result Update(CategoryModel model)
        {
            try
            {
                if (_categoryRepository.GetEntityQuery().Any(c => c.Name.ToUpper() == model.Name.ToUpper().Trim()&&c.Id!=model.Id ))
                {
                    return new ErrorResult("Category with the same name exists!");
                }
                var entity = _categoryRepository.GetEntityQuery(c => c.Id == model.Id).SingleOrDefault();
                
                    entity.Description = model.Description?.Trim();
                    entity.Name = model.Name.Trim();
                
                _categoryRepository.Update(entity);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }
    }
}
