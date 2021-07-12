using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.EntityFramework.Contexts;
using Entities.Entites;
using Business.Services.Bases;
using AppCore.Business.Models.Results;
using Microsoft.Extensions.DependencyInjection;
using Business.Models;

namespace OnlineCicekSepeti.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        //private readonly ECicekSepetiContext _context;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        //public ProductsController(ECicekSepetiContext context)
        //{
        //    _context = context;
        //}

        // GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    var eCicekSepetiContext = _context.Products.Include(p => p.Category);
        //    return View(await eCicekSepetiContext.ToListAsync());
        //}
        
        public IActionResult Index()
        {
           
                var query = _productService.GetQuery();
                
                    var model = query.ToList();
                    return View(model);
               
                    
            
        }

        // GET: Products/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}



        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var query = _productService.GetQuery();
           

            var model = query.SingleOrDefault(p => p.Id == id.Value);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
            //    if (product == null)
            //    {
            //        return NotFound();
            //    }

        




        }











        // GET: Products/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        //    return View();
        //}
        public IActionResult Create()
        {
            var query = _categoryService.GetQuery();
           
            ViewBag.Categories = new SelectList(query.ToList(),"Id","Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Description,UnitPrice,StockAmount,ExpiraionDate,CategoryId,Id,Guid")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        //    return View(product);
        //}



        public IActionResult Create(ProductModel product)
        {
            Result productResult;
            IQueryable<CategoryModel> categoryQuery;
            if (ModelState.IsValid)
            {
                productResult = _productService.Add(product);
                if (productResult.Status == ResultStatus.Exception)
                    throw new Exception(productResult.Massage);
                if(productResult.Status == ResultStatus.Succes)
                {
                return RedirectToAction(nameof(Index));
                }


                //ERROR

                ModelState.AddModelError("", productResult.Massage);
                categoryQuery = _categoryService.GetQuery();
                
                ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", product.CategoryId);
                return View(product);



            }
            categoryQuery = _categoryService.GetQuery();
            
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", product.CategoryId);
            return View(product);
        }









        // GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        //    return View(product);
        //}



        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View("NotFound");
            var productQuery = _productService.GetQuery();
           
            var product = productQuery.SingleOrDefault(p => p.Id == id.Value);
            if(product == null)
                return View("NotFound");
            var categoryQuery = _categoryService.GetQuery();
           
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name",product.CategoryId);
            return View(product);
        }












        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,Description,UnitPrice,StockAmount,ExpiraionDate,CategoryId,Id,Guid")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        //    return View(product);
        //}




        public IActionResult Edit(ProductModel product)
        {
            Result productResult;
            IQueryable<CategoryModel> categoryQuery;
            if (ModelState.IsValid)
            {
                productResult = _productService.Update(product);
                if (productResult.Status == ResultStatus.Exception)
                    throw new Exception(productResult.Massage);
                if (productResult.Status == ResultStatus.Succes)
                {
                    return RedirectToAction(nameof(Index));
                }


                //ERROR

                ModelState.AddModelError("", productResult.Massage);
                categoryQuery = _categoryService.GetQuery();
                
                ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", product.CategoryId);
                return View(product);



            }
            categoryQuery = _categoryService.GetQuery();
           
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", product.CategoryId);
            return View(product);
        }
















        // GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return View("NotFound");
            var result = _productService.Delete(id.Value);
            if (result.Status == ResultStatus.Succes)
                return RedirectToAction(nameof(Index));
            throw new Exception(result.Massage);

        }









    }
}
