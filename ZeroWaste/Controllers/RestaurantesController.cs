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
    public class RestaurantesController : Controller
    {
        private readonly ZeroDbContext _context;

        public RestaurantesController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurante.ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurante
                .FirstOrDefaultAsync(m => m.IDRestaurante == id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDRestaurante,Nome,Telefone,Email,Morada")] Restaurante restaurante)
        {
            var email = restaurante.Email;
            var morada = restaurante.Morada;
            var telefone = restaurante.Telefone;


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
                    _context.Add(restaurante);

                    await _context.SaveChangesAsync();
                    TempData["notice"] = "Registo inserido com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            return View(restaurante);
        }

        private bool emailrepetidoCriar(string email)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com o mesmo email
            var restaurantes = from e in _context.Restaurante
                           where e.Email.Contains(email)
                           select e;

            if (!restaurantes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool moradarepetidaCriar(string morada)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com a mesma morada
            var restaurantes = from e in _context.Restaurante
                               where e.Morada.Contains(morada)
                           select e;

            if (!restaurantes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool contactorepetidoCriar(string contacto)
        {
            bool repetido = false;


            //Procura na BD se o contacto ja existe
            var restaurantes = from e in _context.Restaurante
                               where e.Telefone.Contains(contacto)
                           select e;

            if (!restaurantes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        // GET: Restaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurante.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDRestaurante,Nome,Telefone,Email,Morada")] Restaurante restaurante)
        {

            var email = restaurante.Email;
            var morada = restaurante.Morada;
            var telefone = restaurante.Telefone;
            var idRestaurante = restaurante.IDRestaurante;

            if (id != restaurante.IDRestaurante)
            {
                return NotFound();
            }

            //Validar Email           
            if (emailrepetidoEditar(email, idRestaurante) == true)
            {
                //Mensagem de erro se o email for repetido
                ModelState.AddModelError("Email", "Este email já existe");
            }

            //Validar morada           
            if (moradarepetidaEditar(morada, idRestaurante) == true)
            {
                //Mensagem de erro se a morada ja existir noutro registo
                ModelState.AddModelError("Morada", "Esta morada já foi utilizada");
            }
            //Validar Contacto
            if (contactorepetidoEditar(telefone, idRestaurante))
            {
                //Mensagem de erro se o contacto ja existe
                ModelState.AddModelError("Telefone", "Contacto já utilizado");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!emailrepetidoEditar(email, idRestaurante) || moradarepetidaEditar(morada, idRestaurante) || contactorepetidoEditar(telefone, idRestaurante))
                    {
                        _context.Update(restaurante);
                        await _context.SaveChangesAsync();
                        TempData["successEdit"] = "Registo alterado com sucesso";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestauranteExists(restaurante.IDRestaurante))
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
            return View(restaurante);
        }

        private bool emailrepetidoEditar(string email, int idRestaurante)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com o mesmo email
            var restaurantes = from f in _context.Restaurante
                           where f.Email.Contains(email) && f.IDRestaurante != idRestaurante
                           select f;

            if (!restaurantes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool moradarepetidaEditar(string morada, int idRestaurante)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com a mesma morada
            var restaurantes = from f in _context.Restaurante
                               where f.Morada.Contains(morada) && f.IDRestaurante != idRestaurante
                           select f;

            if (!restaurantes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool contactorepetidoEditar(string contacto, int idRestaurante)
        {
            bool repetido = false;

            //Procura na BD se existem restaurantes com o mesmo contacto
            var restaurantes = from f in _context.Restaurante
                               where f.Telefone.Contains(contacto) && f.IDRestaurante != idRestaurante
                           select f;

            if (!restaurantes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        // GET: Restaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurante
                .FirstOrDefaultAsync(m => m.IDRestaurante == id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurante = await _context.Restaurante.FindAsync(id);
            _context.Restaurante.Remove(restaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestauranteExists(int id)
        {
            return _context.Restaurante.Any(e => e.IDRestaurante == id);
        }
    }
}
