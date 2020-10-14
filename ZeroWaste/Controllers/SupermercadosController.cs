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
            var email = supermercado.Email;
            var morada = supermercado.Morada;
            var telefone = supermercado.Telefone;


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
                    _context.Add(supermercado);

                    await _context.SaveChangesAsync();
                    TempData["notice"] = "Registo inserido com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            return View(supermercado);
        }


        private bool emailrepetidoCriar(string email)
        {
            bool repetido = false;

            //Procura na BD se existem supermercados com o mesmo email
            var supermercados = from e in _context.Supermercado
                               where e.Email.Contains(email)
                               select e;

            if (!supermercados.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool moradarepetidaCriar(string morada)
        {
            bool repetido = false;

            //Procura na BD se existem supermercados com a mesma morada
            var supermercados = from e in _context.Supermercado
                                where e.Morada.Contains(morada)
                               select e;

            if (!supermercados.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool contactorepetidoCriar(string contacto)
        {
            bool repetido = false;


            //Procura na BD se o contacto ja existe
            var supermercados = from e in _context.Supermercado
                                where e.Telefone.Contains(contacto)
                               select e;

            if (!supermercados.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
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
            var email = supermercado.Email;
            var morada = supermercado.Morada;
            var telefone = supermercado.Telefone;
            var idSupermercado = supermercado.IDSupermercado;

            if (id != supermercado.IDSupermercado)
            {
                return NotFound();
            }

            //Validar Email           
            if (emailrepetidoEditar(email, idSupermercado) == true)
            {
                //Mensagem de erro se o email for repetido
                ModelState.AddModelError("Email", "Este email já existe");
            }

            //Validar morada           
            if (moradarepetidaEditar(morada, idSupermercado) == true)
            {
                //Mensagem de erro se a morada ja existir noutro registo
                ModelState.AddModelError("Morada", "Esta morada já foi utilizada");
            }
            //Validar Contacto
            if (contactorepetidoEditar(telefone, idSupermercado))
            {
                //Mensagem de erro se o contacto ja existe
                ModelState.AddModelError("Telefone", "Contacto já utilizado");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    if (!emailrepetidoEditar(email, idSupermercado) || moradarepetidaEditar(morada, idSupermercado) || contactorepetidoEditar(telefone, idSupermercado))
                    {
                        _context.Update(supermercado);
                        await _context.SaveChangesAsync();
                        TempData["successEdit"] = "Registo alterado com sucesso";
                    }
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

        private bool emailrepetidoEditar(string email, int idSupermercado)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com o mesmo email
            var supermercados = from f in _context.Supermercado
                               where f.Email.Contains(email) && f.IDSupermercado != idSupermercado
                               select f;

            if (!supermercados.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool moradarepetidaEditar(string morada, int idSupermercado)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com a mesma morada
            var supermercados = from f in _context.Supermercado
                                where f.Morada.Contains(morada) && f.IDSupermercado != idSupermercado
                               select f;

            if (!supermercados.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool contactorepetidoEditar(string contacto, int idSupermercado)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com o mesmo contacto
            var supermercados = from f in _context.Supermercado
                                where f.Telefone.Contains(contacto) && f.IDSupermercado != idSupermercado
                               select f;

            if (!supermercados.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
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
