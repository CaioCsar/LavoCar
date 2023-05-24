using LavoCar.Conexao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class LavagemController : Controller
    {
        // GET: LavagemController

        private readonly IESContext _context;
        public LavagemController(IESContext context)
        {
            this._context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Lavagens.OrderBy(c => c.DataLav).ToListAsync());
        }

        // GET: LavagemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LavagemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LavagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LavagemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LavagemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LavagemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LavagemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
