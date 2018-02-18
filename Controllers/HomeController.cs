using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PmspProjeto.Models;
using PmspProjeto.Repositorio;

namespace PmspProjeto.Controllers
{
    public class HomeController : Controller
    {
        readonly PmspContext _context;
        public Servidor Servidor { get; set; }
        
        public HomeController(PmspContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var servidores = _context.Servidores.ToList();
            return View(servidores);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind] Servidor servidor)
        {
            _context.Servidores.Add(servidor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int Id)
        {
            var dados = _context.Servidores.Where(s => s.Id == Id).FirstOrDefault();
            return View(dados);
        }

         [HttpGet]
        public IActionResult Detalhes(int Id)
        {
            var dados = _context.Servidores.Where(s => s.Id == Id).FirstOrDefault();
            return View(dados);
        }

        [HttpPost]
        public IActionResult Editar(int Id, [Bind] Servidor servidor)
        {
            if (servidor == null || servidor.Id != Id)
            {
                return RedirectToAction("Index");
            }

            var atualizarServidor = _context.Servidores.Where(s => s.Id == Id).FirstOrDefault();
            if(atualizarServidor == null) 
            {
                return RedirectToAction("Index");
            }

            atualizarServidor.Nome = servidor.Nome;
            atualizarServidor.DataNascimento = servidor.DataNascimento;
            atualizarServidor.EndLogradouro = servidor.EndLogradouro;
            atualizarServidor.EndNumero = servidor.EndNumero;
            atualizarServidor.EndComplemento = servidor.EndComplemento;
            atualizarServidor.EndCEP = servidor.EndCEP;
            atualizarServidor.EndBairro = servidor.EndBairro;
            atualizarServidor.RF = servidor.RF;
            atualizarServidor.Vinculo = servidor.Vinculo;
            atualizarServidor.Cargo = servidor.Cargo;
            atualizarServidor.UnidadeLotacao = servidor.UnidadeLotacao;
            atualizarServidor.UnidadeExercicio = servidor.UnidadeExercicio;


            _context.Servidores.Update(atualizarServidor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Deletar(int Id)
        {
            var servidor = _context.Servidores.Where(s => s.Id == Id).FirstOrDefault();
            if(servidor == null)
                return RedirectToAction("Index");

            _context.Servidores.Remove(servidor);
            _context.SaveChanges();          
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
