using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteFe.Models;

namespace TesteFe.Controllers
{
    public class CartaoPessoaFisicaController : Controller
    {
        private readonly EstacionamentoContext _context;

        public CartaoPessoaFisicaController(EstacionamentoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CartaoPessoaFisica.Include(e => e.Endereco).ToListAsync());
        }

		[HttpGet]
		public async Task<IActionResult> PesquisarNome(string nome)
		{

			return View(nameof(Index), await _context.CartaoPessoaFisica.Where(n => n.Nome.Contains(nome)).ToListAsync());
		}
		[HttpGet]
		public async Task<IActionResult> PesquisarCPF(string cpf)
		{

			return View(nameof(Index), await _context.CartaoPessoaFisica.Where(i => i.CPF.ToString().Contains(cpf) ).ToListAsync());
		}

		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoPessoaFisica = await _context.CartaoPessoaFisica.Include(e => e.Endereco)
                .SingleOrDefaultAsync(m => m.CartaoID == id);
            if (cartaoPessoaFisica == null)
            {
                return NotFound();
            }

            return View(cartaoPessoaFisica);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CPF,Sexo,DataNascimento,RG,CartaoID,Nome,Telefone, Endereco, Email")] CartaoPessoaFisica cartaoPessoaFisica)
        {

            if (CPFExiste(cartaoPessoaFisica))
            {
                TempData["cpf"] = "CPF já cadastrado.";
                return View(cartaoPessoaFisica);
            }

            if (ModelState.IsValid)
            {
                _context.Add(cartaoPessoaFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartaoPessoaFisica);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoPessoaFisica = await _context.CartaoPessoaFisica
                                                   .Include(e => e.Endereco)
                                                   .SingleOrDefaultAsync(m => m.CartaoID == id);
            if (cartaoPessoaFisica == null)
            {
                return NotFound();
            }
            return View(cartaoPessoaFisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CPF,Sexo,DataNascimento,RG,CartaoID,Nome,Telefone, Endereco")] CartaoPessoaFisica cartaoPessoaFisica)
        {
            if (id != cartaoPessoaFisica.CartaoID)
            {
                return NotFound();
            }

            //if (CPFExists(cartaoPessoaFisica) )
            //{
            //    TempData["cpf"] = "CPF já cadastrado.";
            //    return View(cartaoPessoaFisica);
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartaoPessoaFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaoPessoaFisicaExists(cartaoPessoaFisica.CartaoID))
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
            return View(cartaoPessoaFisica);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoPessoaFisica = await _context.CartaoPessoaFisica
                .SingleOrDefaultAsync(m => m.CartaoID == id);
            if (cartaoPessoaFisica == null)
            {
                return NotFound();
            }

            return View(cartaoPessoaFisica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartaoPessoaFisica = await _context.CartaoPessoaFisica.SingleOrDefaultAsync(m => m.CartaoID == id);
            _context.CartaoPessoaFisica.Remove(cartaoPessoaFisica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaoPessoaFisicaExists(int id)
        {
            return _context.CartaoPessoaFisica.Any(e => e.CartaoID == id);
        }
        private bool CPFExiste(CartaoPessoaFisica cartaoPessoaFisica)
        {
            CartaoPessoaFisica cf = _context.CartaoPessoaFisica.FirstOrDefault(x => x.CPF == cartaoPessoaFisica.CPF);
            return cf != null;
        }
    }
}
