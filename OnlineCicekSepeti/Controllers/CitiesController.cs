using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCicekSepeti.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityServices;
        public CitiesController(ICityService cityServices)
        {
            _cityServices = cityServices;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
