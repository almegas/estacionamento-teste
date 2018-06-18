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
    public class CartaoPessoaJuridicaController : Controller
    {
        private readonly EstacionamentoContext _context;

        public CartaoPessoaJuridicaController(EstacionamentoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CartaoPessoaJuridica.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoPessoaJuridica = await _context.CartaoPessoaJuridica
                .SingleOrDefaultAsync(m => m.CartaoID == id);
            if (cartaoPessoaJuridica == null)
            {
                return NotFound();
            }

            return View(cartaoPessoaJuridica);
        }

		[HttpGet]
		public async Task<IActionResult> PesquisarNome(string Razao)
		{

			return View(nameof(Index), await _context.CartaoPessoaJuridica.Where(n => n.Nome.Contains(Razao)).ToListAsync());
		}
		[HttpGet]
		public async Task<IActionResult> PesquisarCPF(string CNPJ)
		{

			return View(nameof(Index), await _context.CartaoPessoaJuridica.Where(i => i.CNPJ.ToString().Contains(CNPJ)).ToListAsync());
		}



		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CNPJ,RazaoSocial,CartaoID,Nome,Telefone,Email, Endereco")] CartaoPessoaJuridica cartaoPessoaJuridica)
        {
            CartaoPessoaJuridica cj = _context.CartaoPessoaJuridica.FirstOrDefault(x => x.CNPJ == cartaoPessoaJuridica.CNPJ);

            if (cj != null)
            {
                TempData["cnpj"] = "CNPJ já cadastrado.";
                return View(cartaoPessoaJuridica);
            }

            if (ModelState.IsValid)
            {
                _context.Add(cartaoPessoaJuridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartaoPessoaJuridica);
        }

        // GET: CartaoPessoaJuridica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoPessoaJuridica = await _context.CartaoPessoaJuridica.SingleOrDefaultAsync(m => m.CartaoID == id);
            if (cartaoPessoaJuridica == null)
            {
                return NotFound();
            }
            return View(cartaoPessoaJuridica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CNPJ,RazaoSocial,CartaoID,Nome,Telefone")] CartaoPessoaJuridica cartaoPessoaJuridica)
        {
            if (id != cartaoPessoaJuridica.CartaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartaoPessoaJuridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaoPessoaJuridicaExists(cartaoPessoaJuridica.CartaoID))
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
            return View(cartaoPessoaJuridica);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoPessoaJuridica = await _context.CartaoPessoaJuridica
                .SingleOrDefaultAsync(m => m.CartaoID == id);
            if (cartaoPessoaJuridica == null)
            {
                return NotFound();
            }

            return View(cartaoPessoaJuridica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartaoPessoaJuridica = await _context.CartaoPessoaJuridica.SingleOrDefaultAsync(m => m.CartaoID == id);
            _context.CartaoPessoaJuridica.Remove(cartaoPessoaJuridica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaoPessoaJuridicaExists(int id)
        {
            return _context.CartaoPessoaJuridica.Any(e => e.CartaoID == id);
        }
    }
}
