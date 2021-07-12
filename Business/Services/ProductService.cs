using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.EntityFramework.Repositories.Bases;
using System.Globalization;
using Entities.Entites;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepositoryBase _productRepository;
        public ProductService(ProductRepositoryBase productRepository)
        {
            _productRepository = productRepository;
        }
        public Result Add(ProductModel model)
        {
            try
            {
                if (_productRepository.GetEntityQuery().Any(p => p.Name.ToUpper() == model.Name.ToUpper().Trim()))
                    return new ErrorResult("Product with the same name exists!");
                double unitPrice;
                //if (!double.TryParse(model.UnitPriceText.Trim().Replace(",", "."), NumberStyles.Any, new CultureInfo("en"), out unitPrice)) ;
                if (!double.TryParse(model.UnitPriceText.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out unitPrice))
                {
                    return new ErrorResult("Unit price must be number!");
                   
                    
                }
                model.UnitPrice = unitPrice;
                var entity = new Product()
                {
                    CategoryId = model.CategoryId,
                    Description = model.Description?.Trim(),
                    Name = model.Name.Trim(),
                    StockAmount = model.StockAmount,
                    UnitPrice = model.UnitPrice
                };
                _productRepository.Add(entity);
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
                _productRepository.Delete(id);
                return new SuccesResult();

            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }

        public IQueryable<ProductModel> GetQuery()
        {
          
                var query = _productRepository.GetEntityQuery("Category").OrderBy(p => p.Name).Select(p => new ProductModel()

                {
                    Id = p.Id,
                    Guid = p.Guid,
                    Name = p.Name,
                    UnitPrice = p.UnitPrice,
                    UnitPriceText = p.UnitPrice.ToString(new CultureInfo("en")),
                    StockAmount = p.StockAmount,
                    Description = p.Description,
                    
                    CategoryId = p.CategoryId,
                    Category = new CategoryModel()
                    {
                        Id = p.Category.Id,
                        Guid = p.Category.Guid,
                        Description = p.Description,
                        Name = p.Category.Name

                    }
                });
            return query;
                 
            
           
            
        }

        public Result Update(ProductModel model)
        {
            try
            {
                if (_productRepository.GetEntityQuery().Any(p => p.Name.ToUpper() == model.Name.ToUpper().Trim() && p.Id != model.Id))
                    return new ErrorResult("Product with the same name exists!");
                double unitPrice;
                //if (!double.TryParse(model.UnitPriceText.Trim().Replace(",", "."), NumberStyles.Any, new CultureInfo("en"), out unitPrice)) ;
                if (!double.TryParse(model.UnitPriceText.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out unitPrice))
                {
                    return new ErrorResult("Unit price must be number!");


                }
                model.UnitPrice = unitPrice;
                var entity = _productRepository.GetEntityQuery(p => p.Id == model.Id).SingleOrDefault();

                entity.CategoryId = model.CategoryId;
                entity.Description = model.Description?.Trim();
                    entity.Name = model.Name.Trim();
                entity.StockAmount = model.StockAmount;
                entity.UnitPrice = model.UnitPrice;
              
                _productRepository.Update(entity);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }
    }
}
