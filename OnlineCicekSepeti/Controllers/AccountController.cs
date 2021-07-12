using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCicekSepeti.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly ICountryService _countryService;
        

        public AccountController( ICountryService countryService)
        {
          
            _countryService = countryService;
           
        }
        public IActionResult Register()
        {
            var countriesResult = _countryService.GetCountries();
            if (countriesResult.Status == ResultStatus.Exception)
                throw new Exception(countriesResult.Massage);
            ViewBag.Countries = new SelectList(countriesResult.Data, "Id", "Name");
            var model = new UserModel();
            return View(model);

        }
    }
}
