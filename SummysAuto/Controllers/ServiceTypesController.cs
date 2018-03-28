using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SummysAuto.Controllers
{
    public class ServiceTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}