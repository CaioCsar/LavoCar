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
        public async Task<IActionResult> Index() {
            return View(await _context.TipoLavagens.OrderBy(n => n.DescTipoLav).ToListAsync());
        }
        // GET: TipoLavagemController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: TipoLavagemController/Create
        public IActionResult Create() {
            return View();
        }

        // POST: TipoLavagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescTipoLav", "PrecoTipoLav")] TipoLavagem tipoLavagem) {
            try {
                if (ModelState.IsValid) {
                    _context.Add(tipoLavagem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException) {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
                return View(tipoLavagem);
        }
        

        // GET: TipoLavagemController/Details/5
        public ActionResult Details(long id) {
            return View();
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
