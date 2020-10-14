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
    public class VoluntariosController : Controller
    {
        private readonly ZeroDbContext _context;

        public VoluntariosController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: Voluntarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voluntarios.ToListAsync());
        }

        // GET: Voluntarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarios = await _context.Voluntarios
                .FirstOrDefaultAsync(m => m.IDVoluntarios == id);
            if (voluntarios == null)
            {
                return NotFound();
            }

            return View(voluntarios);
        }

        // GET: Voluntarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voluntarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDVoluntarios,Nome,Telefone,Email,Morada,DataNasc,NrTotalEntregas")] Voluntarios voluntarios)
        {


            var email = voluntarios.Email;
            var morada = voluntarios.Morada;
            var telefone = voluntarios.Telefone;


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
                    _context.Add(voluntarios);

                    await _context.SaveChangesAsync();
                    TempData["notice"] = "Registo inserido com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            return View(voluntarios);
        }

        private bool emailrepetidoCriar(string email)
        {
            bool repetido = false;

            //Procura na BD se existem voluntarios com o mesmo email
            var voluntarios = from e in _context.Voluntarios
                                where e.Email.Contains(email)
                                select e;

            if (!voluntarios.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool moradarepetidaCriar(string morada)
        {
            bool repetido = false;

            //Procura na BD se existem voluntarios com a mesma morada
            var voluntarios = from e in _context.Voluntarios
                              where e.Morada.Contains(morada)
                                select e;

            if (!voluntarios.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool contactorepetidoCriar(string contacto)
        {
            bool repetido = false;


            //Procura na BD se o contacto ja existe
            var voluntarios = from e in _context.Voluntarios
                              where e.Telefone.Contains(contacto)
                                select e;

            if (!voluntarios.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        // GET: Voluntarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarios = await _context.Voluntarios.FindAsync(id);
            if (voluntarios == null)
            {
                return NotFound();
            }
            return View(voluntarios);
        }

        // POST: Voluntarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDVoluntarios,Nome,Telefone,Email,Morada,DataNasc,NrTotalEntregas")] Voluntarios voluntarios)
        {
            var email = voluntarios.Email;
            var morada = voluntarios.Morada;
            var telefone = voluntarios.Telefone;
            var idVoluntario = voluntarios.IDVoluntarios;


            if (id != voluntarios.IDVoluntarios)
            {
                return NotFound();
            }

            //Validar Email           
            if (emailrepetidoEditar(email, idVoluntario) == true)
            {
                //Mensagem de erro se o email for repetido
                ModelState.AddModelError("Email", "Este email já existe");
            }

            //Validar morada           
            if (moradarepetidaEditar(morada, idVoluntario) == true)
            {
                //Mensagem de erro se a morada ja existir noutro registo
                ModelState.AddModelError("Morada", "Esta morada já foi utilizada");
            }
            //Validar Contacto
            if (contactorepetidoEditar(telefone, idVoluntario))
            {
                //Mensagem de erro se o contacto ja existe
                ModelState.AddModelError("Telefone", "Contacto já utilizado");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!emailrepetidoEditar(email, idVoluntario) || moradarepetidaEditar(morada, idVoluntario) || contactorepetidoEditar(telefone, idVoluntario))
                    {
                        _context.Update(voluntarios);
                        await _context.SaveChangesAsync();
                        TempData["successEdit"] = "Registo alterado com sucesso";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntariosExists(voluntarios.IDVoluntarios))
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
            return View(voluntarios);
        }


        private bool emailrepetidoEditar(string email, int idVoluntario)
        {
            bool repetido = false;

            //Procura na BD se existem familias com o mesmo email
            var voluntarios = from f in _context.Voluntarios
                           where f.Email.Contains(email) && f.IDVoluntarios != idVoluntario
                           select f;

            if (!voluntarios.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool moradarepetidaEditar(string morada, int idVoluntario)
        {
            bool repetido = false;

            //Procura na BD se existem familias com a mesma morada
            var voluntarios = from f in _context.Voluntarios
                              where f.Morada.Contains(morada) && f.IDVoluntarios != idVoluntario
                           select f;

            if (!voluntarios.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool contactorepetidoEditar(string contacto, int idVoluntario)
        {
            bool repetido = false;

            //Procura na BD se existem familias com o mesmo contacto
            var voluntarios = from f in _context.Voluntarios
                              where f.Telefone.Contains(contacto) && f.IDVoluntarios != idVoluntario
                           select f;

            if (!voluntarios.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        // GET: Voluntarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarios = await _context.Voluntarios
                .FirstOrDefaultAsync(m => m.IDVoluntarios == id);
            if (voluntarios == null)
            {
                return NotFound();
            }

            return View(voluntarios);
        }

        // POST: Voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voluntarios = await _context.Voluntarios.FindAsync(id);
            _context.Voluntarios.Remove(voluntarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntariosExists(int id)
        {
            return _context.Voluntarios.Any(e => e.IDVoluntarios == id);
        }
    }
}
