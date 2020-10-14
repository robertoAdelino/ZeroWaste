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
    public class FamiliasController : Controller
    {
        private const int PAGE_SIZE = 5;
        private readonly ZeroDbContext _context;

        public FamiliasController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: Familias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Familias.ToListAsync());
        }

        // GET: Familias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familias = await _context.Familias
                .FirstOrDefaultAsync(m => m.IDFamilias == id);
            if (familias == null)
            {
                return NotFound();
            }

            return View(familias);
        }

        // GET: Familias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Familias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFamilias,Nome,Telefone,Email,Morada,Rendimento,NumeroPessoasAgregado")] Familias familias)
        {
            var email = familias.Email;
            var morada = familias.Morada;
            var telefone = familias.Telefone;


            //Validar Email           
            if (emailrepetidoCriar(email) == true)
            {
                //Mensagem de erro se o email for inválido
                ModelState.AddModelError("Email", "Este email já existe");
            }

            //Validar morada           
            if (moradarepetidaCriar(morada) == true)
            {
                //Mensagem de erro se a morada ja existir noutro registo
                ModelState.AddModelError("Morada", "Esta morada já foi utilizada");
            }
            //Validar Contacto
            if (contactorepetidoCriar(telefone))
            {
                //Mensagem de erro se o contacto ja existe
                ModelState.AddModelError("Telefone", "Contacto já utilizado");
            }



            if (ModelState.IsValid)
                if (!emailrepetidoCriar(email) || moradarepetidaCriar(morada) || contactorepetidoCriar(telefone))
                {
                    _context.Add(familias);

                    await _context.SaveChangesAsync();
                    TempData["notice"] = "Registo inserido com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            return View(familias);
        }

        private bool emailrepetidoCriar(string email)
        {
            bool repetido = false;

            //Procura na BD se existem familias com o mesmo email
            var familias = from e in _context.Familias
                              where e.Email.Contains(email)
                              select e;

            if (!familias.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool moradarepetidaCriar(string morada)
        {
            bool repetido = false;

            //Procura na BD se existem familias com a mesma morada
            var familias = from e in _context.Familias
                           where e.Morada.Contains(morada)
                           select e;

            if (!familias.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool contactorepetidoCriar(string contacto)
        {
            bool repetido = false;


            //Procura na BD se o contacto ja existe
            var familias = from e in _context.Familias
                              where e.Telefone.Contains(contacto)
                              select e;

            if (!familias.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }



        // GET: Familias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familias = await _context.Familias.FindAsync(id);
            if (familias == null)
            {
                return NotFound();
            }
            return View(familias);
        }

        // POST: Familias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFamilias,Nome,Telefone,Email,Morada,Rendimento,NumeroPessoasAgregado")] Familias familias)
        {
            var email = familias.Email;
            var morada = familias.Morada;
            var telefone = familias.Telefone;
            var idFamilia = familias.IDFamilias;

            if (id != familias.IDFamilias)
            {
                return NotFound();
            }

            //Validar Email           
            if (emailrepetidoEditar(email, idFamilia) == true)
            {
                //Mensagem de erro se o email for repetido
                ModelState.AddModelError("Email", "Este email já existe");
            }

            //Validar morada           
            if (moradarepetidaEditar(morada, idFamilia) == true)
            {
                //Mensagem de erro se a morada ja existir noutro registo
                ModelState.AddModelError("Morada", "Esta morada já foi utilizada");
            }
            //Validar Contacto
            if (contactorepetidoEditar(telefone, idFamilia))
            {
                //Mensagem de erro se o contacto ja existe
                ModelState.AddModelError("Telefone", "Contacto já utilizado");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    if (!emailrepetidoEditar(email, idFamilia) || moradarepetidaEditar(morada, idFamilia) || contactorepetidoEditar(telefone, idFamilia))
                    {
                        _context.Update(familias);
                    await _context.SaveChangesAsync();
                        TempData["successEdit"] = "Registo alterado com sucesso";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliasExists(familias.IDFamilias))
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
            return View(familias);
        }

        private bool emailrepetidoEditar(string email, int idFamilia)
        {
            bool repetido = false;

            //Procura na BD se existem familias com o mesmo email
            var familias = from f in _context.Familias
                          where f.Email.Contains(email) && f.IDFamilias != idFamilia
                          select f;

            if (!familias.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool moradarepetidaEditar(string morada, int idFamilia)
        {
            bool repetido = false;

            //Procura na BD se existem familias com a mesma morada
            var familias = from f in _context.Familias
                           where f.Morada.Contains(morada) && f.IDFamilias != idFamilia
                           select f;

            if (!familias.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool contactorepetidoEditar(string contacto, int idFamilia)
        {
            bool repetido = false;

            //Procura na BD se existem familias com o mesmo contacto
            var familias = from f in _context.Familias
                           where f.Telefone.Contains(contacto) && f.IDFamilias != idFamilia
                           select f;

            if (!familias.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        // GET: Familias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familias = await _context.Familias
                .FirstOrDefaultAsync(m => m.IDFamilias == id);
            if (familias == null)
            {
                return NotFound();
            }

            return View(familias);
        }

        // POST: Familias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familias = await _context.Familias.FindAsync(id);
            _context.Familias.Remove(familias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliasExists(int id)
        {
            return _context.Familias.Any(e => e.IDFamilias == id);
        }
    }
}
