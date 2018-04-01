using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
                return View(serviceType);

            _db.Add(serviceType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //ServiceTypes/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
                return NotFound();
            return View(serviceType);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
        }
    }
}