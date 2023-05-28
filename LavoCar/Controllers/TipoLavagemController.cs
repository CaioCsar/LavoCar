using Microsoft.AspNetCore.Http;
using LavoCar.Conexao;
using LavoCar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LavoCar.Controllers
{
    public class TipoLavagemController : Controller
    {

        //CONNECTION
        private readonly IESContext _context;

        public TipoLavagemController(IESContext context)
        {
            this._context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoLavagens.Include(t => t.Lavagem).OrderBy(n => n.DescTipoLav).ToListAsync());
        }

        // CREATE
        public IActionResult Create()
        {
            var tipolavagem = _context.TipoLavagens.OrderBy(i => i.DescTipoLav).ToList();
            tipolavagem.Insert(0, new TipoLavagem() { TipoLavID = 0, DescTipoLav = "Tipo de Lavagem" });
            ViewBag.TiposLavagens = tipolavagem;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescTipoLav, PrecoTipoLav, LavagemID")] TipoLavagem tipoLavagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tipoLavagem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            ViewBag.Lavagens = new SelectList(_context.Lavagens.OrderBy(b => b.DataLav), "LavID", "DataLav");
            return View(tipoLavagem);
        }

        // EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            if (tipolavagem == null)
            {
                return NotFound();
            }
            //ViewBag.Lavagem = new SelectList(_context.Lavagens.OrderBy(b => b.ValorLav), "LavagemID", "Valor");
            return View(tipolavagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("TipoLavID, DescTipoLav, PrecoTipoLav")] TipoLavagem tipoLavagem)
        {
            if (id != tipoLavagem.TipoLavID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoLavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoLavExists(tipoLavagem.TipoLavID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoLavagem);
        }
        private bool TipoLavExists(long? id)
        {
            return _context.TipoLavagens.Any(e => e.TipoLavID == id);
        }

        //DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipolav = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            _context.Lavagens.Where(i => tipolav.LavID == i.LavID).Load();
            if (tipolav == null)
            {
                return NotFound();
            }
            return View(tipolav);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            _context.TipoLavagens.Where(i => tipolavagem.LavID == i.LavID).Load();
            if (tipolavagem == null)
            {
                return NotFound();
            }
            return View(tipolavagem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            _context.TipoLavagens.Remove(tipolavagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}