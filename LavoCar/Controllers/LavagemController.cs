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
        public async Task<ActionResult> DetailsAsync(int id)
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
