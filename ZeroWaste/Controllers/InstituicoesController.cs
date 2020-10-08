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
    public class InstituicoesController : Controller
    {
        private readonly ZeroDbContext _context;

        public InstituicoesController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: Instituicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.ToListAsync());
        }

        // GET: Instituicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.IDInstituicoes == id);
            if (instituicoes == null)
            {
                return NotFound();
            }

            return View(instituicoes);
        }

        // GET: Instituicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDInstituicoes,Nome,Telefone,Email,Morada,NumeroPessoasAbrangidas")] Instituicoes instituicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicoes);
        }

        // GET: Instituicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.Instituicoes.FindAsync(id);
            if (instituicoes == null)
            {
                return NotFound();
            }
            return View(instituicoes);
        }

        // POST: Instituicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDInstituicoes,Nome,Telefone,Email,Morada,NumeroPessoasAbrangidas")] Instituicoes instituicoes)
        {
            if (id != instituicoes.IDInstituicoes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicoesExists(instituicoes.IDInstituicoes))
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
            return View(instituicoes);
        }

        // GET: Instituicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.IDInstituicoes == id);
            if (instituicoes == null)
            {
                return NotFound();
            }

            return View(instituicoes);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicoes = await _context.Instituicoes.FindAsync(id);
            _context.Instituicoes.Remove(instituicoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicoesExists(int id)
        {
            return _context.Instituicoes.Any(e => e.IDInstituicoes == id);
        }
    }
}
