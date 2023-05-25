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
        public async Task<IActionResult> Details(long? id) {
            if (id == null) {
                return NotFound();
            }
            var tipoLavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            if (tipoLavagem == null) {
                return NotFound();
            }
            return View(tipoLavagem);
        }

        // GET: TipoLavagemController/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null) {
                return NotFound();
            }
            var tipoLavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            if (tipoLavagem == null) {
                return NotFound();
            }
            return View(tipoLavagem);
        }

        // POST: TipoLavagemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("TipoLavID, DescTipoLav, PrecoTipoLav")] TipoLavagem tipoLavagem) {
            if (id != tipoLavagem.TipoLavID) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                try {
                    _context.Update(tipoLavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TipoLavagemExists(tipoLavagem.TipoLavID)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
                return View(tipoLavagem);
        }
        private bool TipoLavagemExists(long? id) {
            return _context.TipoLavagens.Any(e=>e.TipoLavID==id);
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
