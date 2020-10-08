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
    public class PedidoSupermercadosController : Controller
    {
        private readonly ZeroDbContext _context;

        public PedidoSupermercadosController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: PedidoSupermercados
        public async Task<IActionResult> Index()
        {
            var zeroDbContext = _context.PedidoSupermercado.Include(p => p.Familias).Include(p => p.Instituicoes).Include(p => p.ProdutosSupermercado).Include(p => p.Voluntarios);
            return View(await zeroDbContext.ToListAsync());
        }

        // GET: PedidoSupermercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoSupermercado = await _context.PedidoSupermercado
                .Include(p => p.Familias)
                .Include(p => p.Instituicoes)
                .Include(p => p.ProdutosSupermercado)
                .Include(p => p.Voluntarios)
                .FirstOrDefaultAsync(m => m.IDPedidoSupermercado == id);
            if (pedidoSupermercado == null)
            {
                return NotFound();
            }

            return View(pedidoSupermercado);
        }

        // GET: PedidoSupermercados/Create
        public IActionResult Create()
        {
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email");
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email");
            ViewData["IDProdutosSupermercado"] = new SelectList(_context.ProdutosSupermercado, "IDProdutosSupermercado", "Nome");
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email");
            return View();
        }

        // POST: PedidoSupermercados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPedidoSupermercado,Quantidade,EstadoEntrega,DataEntrega,IDFamilias,IDInstituicoes,IDProdutosSupermercado,IDVoluntarios")] PedidoSupermercado pedidoSupermercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoSupermercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email", pedidoSupermercado.IDFamilias);
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email", pedidoSupermercado.IDInstituicoes);
            ViewData["IDProdutosSupermercado"] = new SelectList(_context.ProdutosSupermercado, "IDProdutosSupermercado", "Nome", pedidoSupermercado.IDProdutosSupermercado);
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email", pedidoSupermercado.IDVoluntarios);
            return View(pedidoSupermercado);
        }

        // GET: PedidoSupermercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoSupermercado = await _context.PedidoSupermercado.FindAsync(id);
            if (pedidoSupermercado == null)
            {
                return NotFound();
            }
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email", pedidoSupermercado.IDFamilias);
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email", pedidoSupermercado.IDInstituicoes);
            ViewData["IDProdutosSupermercado"] = new SelectList(_context.ProdutosSupermercado, "IDProdutosSupermercado", "Nome", pedidoSupermercado.IDProdutosSupermercado);
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email", pedidoSupermercado.IDVoluntarios);
            return View(pedidoSupermercado);
        }

        // POST: PedidoSupermercados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPedidoSupermercado,Quantidade,EstadoEntrega,DataEntrega,IDFamilias,IDInstituicoes,IDProdutosSupermercado,IDVoluntarios")] PedidoSupermercado pedidoSupermercado)
        {
            if (id != pedidoSupermercado.IDPedidoSupermercado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoSupermercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoSupermercadoExists(pedidoSupermercado.IDPedidoSupermercado))
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
            ViewData["IDFamilias"] = new SelectList(_context.Familias, "IDFamilias", "Email", pedidoSupermercado.IDFamilias);
            ViewData["IDInstituicoes"] = new SelectList(_context.Instituicoes, "IDInstituicoes", "Email", pedidoSupermercado.IDInstituicoes);
            ViewData["IDProdutosSupermercado"] = new SelectList(_context.ProdutosSupermercado, "IDProdutosSupermercado", "Nome", pedidoSupermercado.IDProdutosSupermercado);
            ViewData["IDVoluntarios"] = new SelectList(_context.Voluntarios, "IDVoluntarios", "Email", pedidoSupermercado.IDVoluntarios);
            return View(pedidoSupermercado);
        }

        // GET: PedidoSupermercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoSupermercado = await _context.PedidoSupermercado
                .Include(p => p.Familias)
                .Include(p => p.Instituicoes)
                .Include(p => p.ProdutosSupermercado)
                .Include(p => p.Voluntarios)
                .FirstOrDefaultAsync(m => m.IDPedidoSupermercado == id);
            if (pedidoSupermercado == null)
            {
                return NotFound();
            }

            return View(pedidoSupermercado);
        }

        // POST: PedidoSupermercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoSupermercado = await _context.PedidoSupermercado.FindAsync(id);
            _context.PedidoSupermercado.Remove(pedidoSupermercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoSupermercadoExists(int id)
        {
            return _context.PedidoSupermercado.Any(e => e.IDPedidoSupermercado == id);
        }
    }
}
