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
            var email = instituicoes.Email;
            var morada = instituicoes.Morada;
            var telefone = instituicoes.Telefone;


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
                    _context.Add(instituicoes);

                    await _context.SaveChangesAsync();
                    TempData["notice"] = "Registo inserido com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            return View(instituicoes);
        }

        private bool emailrepetidoCriar(string email)
        {
            bool repetido = false;

            //Procura na BD se existem instituicoes com o mesmo email
            var instituicoes = from e in _context.Instituicoes
                           where e.Email.Contains(email)
                           select e;

            if (!instituicoes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool moradarepetidaCriar(string morada)
        {
            bool repetido = false;

            //Procura na BD se existem instituicoes com a mesma morada
            var instituicoes = from e in _context.Instituicoes
                           where e.Morada.Contains(morada)
                           select e;

            if (!instituicoes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }

        private bool contactorepetidoCriar(string contacto)
        {
            bool repetido = false;


            //Procura na BD se o contacto ja existe
            var instituicoes = from e in _context.Instituicoes
                           where e.Telefone.Contains(contacto)
                           select e;

            if (!instituicoes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
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
            var email = instituicoes.Email;
            var morada = instituicoes.Morada;
            var telefone = instituicoes.Telefone;
            var idInstituicao = instituicoes.IDInstituicoes;

            if (id != instituicoes.IDInstituicoes)
            {
                return NotFound();
            }

            //Validar Email           
            if (emailrepetidoEditar(email, idInstituicao) == true)
            {
                //Mensagem de erro se o email for repetido
                ModelState.AddModelError("Email", "Este email já existe");
            }

            //Validar morada           
            if (moradarepetidaEditar(morada, idInstituicao) == true)
            {
                //Mensagem de erro se a morada ja existir noutro registo
                ModelState.AddModelError("Morada", "Esta morada já foi utilizada");
            }
            //Validar Contacto
            if (contactorepetidoEditar(telefone, idInstituicao))
            {
                //Mensagem de erro se o contacto ja existe
                ModelState.AddModelError("Telefone", "Contacto já utilizado");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!emailrepetidoEditar(email, idInstituicao) || moradarepetidaEditar(morada, idInstituicao) || contactorepetidoEditar(telefone, idInstituicao))
                    {
                        _context.Update(instituicoes);
                        await _context.SaveChangesAsync();
                        TempData["successEdit"] = "Registo alterado com sucesso";
                    }
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

        private bool emailrepetidoEditar(string email, int idInstituicao)
        {
            bool repetido = false;

            //Procura na BD se existem familias com o mesmo email
            var instituicoes = from f in _context.Instituicoes
                           where f.Email.Contains(email) && f.IDInstituicoes != idInstituicao
                           select f;

            if (!instituicoes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool moradarepetidaEditar(string morada, int idInstituicao)
        {
            bool repetido = false;

            //Procura na BD se existem familias com a mesma morada
            var instituicoes = from f in _context.Instituicoes
                           where f.Morada.Contains(morada) && f.IDInstituicoes != idInstituicao
                           select f;

            if (!instituicoes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
        }
        private bool contactorepetidoEditar(string contacto, int idInstituicao)
        {
            bool repetido = false;

            //Procura na BD se existem familias com o mesmo contacto
            var instituicoes = from f in _context.Instituicoes
                           where f.Telefone.Contains(contacto) && f.IDInstituicoes != idInstituicao
                           select f;

            if (!instituicoes.Count().Equals(0))
            {
                repetido = true;
            }

            return repetido;
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
