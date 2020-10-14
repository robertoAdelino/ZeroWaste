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
    public class TiposController : Controller
    {
        private readonly ZeroDbContext _context;

        public TiposController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: Tipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo.ToListAsync());
        }

        // GET: Tipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo
                .FirstOrDefaultAsync(m => m.IDTipo == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // GET: Tipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDTipo,Nome")] Tipo tipo)
        {
            var nome = tipo.Nome;

            // Validar Tipo
            if (tiporepetidoCriar(nome) == true)
            {
                //Mensagem de erro se o tipo for inválido
                ModelState.AddModelError("Nome", "Este Tipo já existe");
            }

            if (ModelState.IsValid)
            {
                if (!tiporepetidoCriar(nome))
                {
                    _context.Add(tipo);

                    await _context.SaveChangesAsync();
                    TempData["notice"] = "Registo inserido com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(tipo);
        }

        private bool tiporepetidoCriar(string nome)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com o mesmo email
            var tipos = from e in _context.Tipo
                                where e.Nome.Contains(nome)
                                select e;

            if (!tipos.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        // GET: Tipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        // POST: Tipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDTipo,Nome")] Tipo tipo)
        {

            var nome = tipo.Nome;
            var idTipo = tipo.IDTipo;

            if (id != tipo.IDTipo)
            {
                return NotFound();
            }
            //Validar tipo           
            if (tiporepetidoEditar(nome, idTipo) == true)
            {
                //Mensagem de erro se o tipo for repetido
                ModelState.AddModelError("Nome", "Este Tipo já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!tiporepetidoEditar(nome, idTipo) )
                    {
                        _context.Update(tipo);
                        await _context.SaveChangesAsync();
                        TempData["successEdit"] = "Registo alterado com sucesso";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExists(tipo.IDTipo))
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
            return View(tipo);
        }
        private bool tiporepetidoEditar(string nome, int idTipo)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com o mesmo email
            var tipos = from f in _context.Tipo
                                where f.Nome.Contains(nome) && f.IDTipo != idTipo
                                select f;

            if (!tipos.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        // GET: Tipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo
                .FirstOrDefaultAsync(m => m.IDTipo == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: Tipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo = await _context.Tipo.FindAsync(id);
            _context.Tipo.Remove(tipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExists(int id)
        {
            return _context.Tipo.Any(e => e.IDTipo == id);
        }
    }
}
