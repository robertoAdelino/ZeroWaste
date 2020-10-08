using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZeroWaste.Models;

namespace ZeroWaste.Controllers
{
    public class PedidoRestaurantesController : Controller
    {
        private readonly ZeroDbContext _context;

        public PedidoRestaurantesController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: PedidoRestaurantes
        public async Task<IActionResult> Index()
        {
            var zeroDbContext = _context.PedidoRestaurante.Include(p => p.Familias).Include(p => p.Instituicoes).Include(p => p.RefeicoesRestaurante).Include(p => p.Voluntarios);
            return View(await zeroDbContext.ToListAsync());
        }

        // GET: PedidoRestaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoRestaurante = await _context.PedidoRestaurante
                .Include(p => p.Familias)
                .Include(p => p.Instituicoes)
                .Include(p => p.RefeicoesRestaurante)
                .Include(p => p.Voluntarios)
                .FirstOrDefaultAsync(m => m.IDPedidoRestaurante == id);
            if (pedidoRestaurante == null)
            {
                return NotFound();
            }

            return View(pedidoRestaurante);
        }

        // GET: PedidoRestaurantes/Create
        public IActionResult Create()
        {
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email");
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email");
            ViewData["IDRefeicoesRestaurante"] = new SelectList(_context.RefeicoesRestaurante, "IDRefeicoesRestaurante", "Nome");
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email");
            return View();
        }

        // POST: PedidoRestaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPedidoRestaurante,Quantidade,EstadoEntrega,DataEntrega,IDFamilias,IDInstituicoes,IDRefeicoesRestaurante,IDVoluntarios")] PedidoRestaurante pedidoRestaurante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoRestaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email", pedidoRestaurante.IDFamilias);
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email", pedidoRestaurante.IDInstituicoes);
            ViewData["IDRefeicoesRestaurante"] = new SelectList(_context.RefeicoesRestaurante, "IDRefeicoesRestaurante", "Nome", pedidoRestaurante.IDRefeicoesRestaurante);
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email", pedidoRestaurante.IDVoluntarios);
            return View(pedidoRestaurante);
        }

        // GET: PedidoRestaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoRestaurante = await _context.PedidoRestaurante.FindAsync(id);
            if (pedidoRestaurante == null)
            {
                return NotFound();
            }
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email", pedidoRestaurante.IDFamilias);
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email", pedidoRestaurante.IDInstituicoes);
            ViewData["IDRefeicoesRestaurante"] = new SelectList(_context.RefeicoesRestaurante, "IDRefeicoesRestaurante", "Nome", pedidoRestaurante.IDRefeicoesRestaurante);
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email", pedidoRestaurante.IDVoluntarios);
            return View(pedidoRestaurante);
        }

        // POST: PedidoRestaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPedidoRestaurante,Quantidade,EstadoEntrega,DataEntrega,IDFamilias,IDInstituicoes,IDRefeicoesRestaurante,IDVoluntarios")] PedidoRestaurante pedidoRestaurante)
        {
            if (id != pedidoRestaurante.IDPedidoRestaurante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoRestaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoRestauranteExists(pedidoRestaurante.IDPedidoRestaurante))
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
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email", pedidoRestaurante.IDFamilias);
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email", pedidoRestaurante.IDInstituicoes);
            ViewData["IDRefeicoesRestaurante"] = new SelectList(_context.RefeicoesRestaurante, "IDRefeicoesRestaurante", "Nome", pedidoRestaurante.IDRefeicoesRestaurante);
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email", pedidoRestaurante.IDVoluntarios);
            return View(pedidoRestaurante);
        }

        // GET: PedidoRestaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoRestaurante = await _context.PedidoRestaurante
                .Include(p => p.Familias)
                .Include(p => p.Instituicoes)
                .Include(p => p.RefeicoesRestaurante)
                .Include(p => p.Voluntarios)
                .FirstOrDefaultAsync(m => m.IDPedidoRestaurante == id);
            if (pedidoRestaurante == null)
            {
                return NotFound();
            }

            return View(pedidoRestaurante);
        }

        // POST: PedidoRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoRestaurante = await _context.PedidoRestaurante.FindAsync(id);
            _context.PedidoRestaurante.Remove(pedidoRestaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoRestauranteExists(int id)
        {
            return _context.PedidoRestaurante.Any(e => e.IDPedidoRestaurante == id);
        }
    }
}
