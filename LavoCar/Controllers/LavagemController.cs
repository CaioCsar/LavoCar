using LavoCar.Conexao;
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
            return View(await _context.Lavagens.Include(t => t.TipoLavagens).OrderBy(c => c.DataLav).ToListAsync());
        }


        // GET: LavagemController/Create
        public ActionResult Create()
         
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataLav, ValorLav")] Lavagem lavagem)
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
            return View(lavagem);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("LavID, DataLav, ValorLav")] Lavagem lavagem)
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

        //DETAILS
        public async Task<IActionResult> Details(long? id)
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
            return View(lavagem);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
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
            return View(lavagem);
        }

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
