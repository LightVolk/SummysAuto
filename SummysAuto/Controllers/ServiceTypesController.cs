using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummysAuto.Data;
using SummysAuto.Models;

namespace SummysAuto.Controllers
{
    public class ServiceTypesController : Controller
    {

        private ApplicationDbContext _db;
        public ServiceTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
        }

        /// <summary>
        /// Get Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post ServiceTypes/Create
        /// </summary>
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
                return View(serviceType);

            _db.Add(serviceType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
        }
    }
}