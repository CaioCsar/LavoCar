﻿using LavoCar.Conexao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<ActionResult> DetailsAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipolavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            _context.TipoLavagens.Where(i => tipolavagem.TipoLavagemID == i.TipoLavID).Load();

            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            _context.Lavagens.Where(i => lavagem.LavID == i.LavID).Load();

            if (lavagem == null)
            {
                return NotFound();
            }
            return View(lavagem);
        }

        // GET: LavagemController/Create
        public ActionResult Create()
         
        {
            var tipolavagem = _context.TipoLavagens.OrderBy(i => i.DescTipoLav).ToList();
            tipolavagem.Insert(0, new TipoLavagem() { TipoLavID = 0, DescTipoLav = "Selecione um tipo de lavagem" });
            ViewBag.TipoLavagem = tipolavagem;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataLav, TipoLavID")] Lavagem lavagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lavagem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(lavagem);
        }

        // GET: LavagemController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            if (lavagem == null)
            {
                return NotFound();
            }
            ViewBag.TipoLavagem = new SelectList(_context.TipoLavagens.OrderBy(b => b.TipoLavID), "TipoLavID", "DescTipoLav");
            return View(lavagem);
            
        }

        // POST: LavagemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        //CONTINUAR FAZER AS AUTERÇÃO DO CONTROLE,DELETE
        public async Task<ActionResult> Edit(long? id, [Bind("LavagemID, TipoLavagemID")] Lavagem lavagem)
        {

            if (id != lavagem.LavID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LavagemExists(lavagem.LavID))
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
        return View(lavagem);
        }
         private bool LavagemExists(long? id)
         {
        return _context.Lavagens.Any(e => e.LavID == id);
            }

    // GET: LavagemController/Delete/5
    public  async Task<IActionResult> Delete(long? id)
        {
        if (id == null)
        {
            return NotFound();
        }
        var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
        _context.TipoLavagens.Where(i => lavagem.TipoLavagemID == i.TipoLavID).Load();
        if (lavagem == null)
        {
            return NotFound();
        }
        return View(lavagem);
    }

        // POST: LavagemController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            _context.Lavagens.Remove(lavagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
