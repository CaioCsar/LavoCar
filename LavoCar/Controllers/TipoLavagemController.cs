using Microsoft.AspNetCore.Http;
using LavoCar.Conexao;
using LavoCar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LavoCar.Controllers {
    public class TipoLavagemController : Controller {

        private readonly IESContext _context;

        public TipoLavagemController(IESContext context) {
            this._context = context;
        }

        // GET: TipoLavagemController
       /* public async Task<IActionResult> Index() {
           // return View(await _context.TipoLavagens.Include(i=> i.Lavagem).OderBy(c=>c.DescTipoLav).ToListAsync());
        }   Depois tem que consertar esse campo da função*/

        // GET: TipoLavagemController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: TipoLavagemController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: TipoLavagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: TipoLavagemController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: TipoLavagemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: TipoLavagemController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: TipoLavagemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
