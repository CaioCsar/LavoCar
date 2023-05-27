using LavoCar.Conexao;
using LavoCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class ReciboController : Controller
    {
        //CONNECTION
        private readonly IESContext _context;

        public ReciboController(IESContext context)
        {
            this._context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recibos.Include(c => c.Cliente).Include(g => g.Lavagem).
                Include(e => e.Carro).Include(l => l.TipoLavagem).ToListAsync());
        }

        // CREATE
        public IActionResult Create()
        {
            //incluir cliente
            var cliente = _context.Clientes.OrderBy(i => i.NomeCliente).ToList();
            cliente.Insert(0, new Cliente() { ClienteID = 0, NomeCliente = "Selecione um Cliente" });
            ViewBag.Clientes = cliente;

            //incluir carro
            var carro = _context.Carros.OrderBy(i => i.Modelo).ToList();
            carro.Insert(0, new Carro() { CarroID = 0, Modelo = "Selecione um Modelo" });
            ViewBag.Carros = carro;

            //incluir lavagem
            var lavagem = _context.Lavagens.OrderBy(i => i.DataLav).ToList();
            lavagem.Insert(0, new Lavagem() { LavID = 0, DataLav = DateTime.Now });
            ViewBag.Lavagens = lavagem;

            //incluir tipo de lavagem
            var tipoLavagem = _context.TipoLavagens.OrderBy(i => i.DescTipoLav).ToList();
            tipoLavagem.Insert(0, new TipoLavagem() { TipoLavID = 0, DescTipoLav = "Selecione uma Lavagem" });
            ViewBag.TipoLavagens = tipoLavagem;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteID, CarroID, LavID, LavagemID")] Recibo recibo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recibo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(recibo);
        }
    }
}
