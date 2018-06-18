using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteFe.Models;
using TesteFe.Models.ViewModels;

namespace TesteFe.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstacionamentoContext _context;

        public HomeController(EstacionamentoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            EstacionamentoCartoesViewModel cartoesViewModel = new EstacionamentoCartoesViewModel();
            cartoesViewModel.CartoesPessoaFisica = _context.CartaoPessoaFisica.ToList();
            cartoesViewModel.CartoesPessoaJuridica = _context.CartaoPessoaJuridica.ToList();
            return View(cartoesViewModel);
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Meu contato.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
