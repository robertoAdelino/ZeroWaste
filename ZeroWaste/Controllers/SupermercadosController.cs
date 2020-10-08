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
    public class SupermercadosController : Controller
    {
        private readonly ZeroDbContext _context;

        public SupermercadosController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: Supermercados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supermercado.ToListAsync());
        }

        // GET: Supermercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supermercado = await _context.Supermercado
                .FirstOrDefaultAsync(m => m.IDSupermercado == id);
            if (supermercado == null)
            {
                return NotFound();
            }

            return View(supermercado);
        }

        // GET: Supermercados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supermercados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSupermercado,Nome,Telefone,Email,Morada")] Supermercado supermercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supermercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supermercado);
        }

        // GET: Supermercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supermercado = await _context.Supermercado.FindAsync(id);
            if (supermercado == null)
            {
                return NotFound();
            }
            return View(supermercado);
        }

        // POST: Supermercados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDSupermercado,Nome,Telefone,Email,Morada")] Supermercado supermercado)
        {
            if (id != supermercado.IDSupermercado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supermercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupermercadoExists(supermercado.IDSupermercado))
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
            return View(supermercado);
        }

        // GET: Supermercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supermercado = await _context.Supermercado
                .FirstOrDefaultAsync(m => m.IDSupermercado == id);
            if (supermercado == null)
            {
                return NotFound();
            }

            return View(supermercado);
        }

        // POST: Supermercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supermercado = await _context.Supermercado.FindAsync(id);
            _context.Supermercado.Remove(supermercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupermercadoExists(int id)
        {
            return _context.Supermercado.Any(e => e.IDSupermercado == id);
        }
    }
}
