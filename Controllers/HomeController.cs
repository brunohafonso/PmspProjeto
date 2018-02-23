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
            dados.Endereco = _context.Enderecos.Where(e => e.Id == Id).FirstOrDefault();
            return View(dados);
        }

        [HttpGet]
        public IActionResult Detalhes(int Id)
        {
            var dados = _context.Servidores.Where(s => s.Id == Id).FirstOrDefault();
            dados.Endereco = _context.Enderecos.Where(e => e.Id == Id).FirstOrDefault();
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
            var atualizarEndereco = _context.Enderecos.Where(s => s.Id == Id).FirstOrDefault();
            //var AtualizarVinculo =;
            if (atualizarServidor == null)
            {
                return RedirectToAction("Index");
            }

            atualizarServidor.Nome = servidor.Nome;
            atualizarServidor.DataNascimento = servidor.DataNascimento;
            atualizarEndereco.Logradouro = servidor.Endereco.Logradouro;
            atualizarEndereco.Numero = servidor.Endereco.Numero;
            atualizarEndereco.Complemento = servidor.Endereco.Complemento;
            atualizarEndereco.CEP = servidor.Endereco.CEP;
            atualizarServidor.RF = servidor.RF;
            // atualizarServidor.Vinculo = servidor.Vinculo;
            // atualizarServidor.Cargo = servidor.Cargo;
            // atualizarServidor.UnidadeLotacao = servidor.UnidadeLotacao;
            // atualizarServidor.UnidadeExercicio = servidor.UnidadeExercicio;


            _context.Servidores.Update(atualizarServidor);
            _context.Enderecos.Update(atualizarEndereco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Deletar(int Id)
        {
            var servidor = _context.Servidores.Where(s => s.Id == Id).FirstOrDefault();
            var endereco = _context.Enderecos.Where(e => e.Id == Id).FirstOrDefault();
            if (servidor == null && endereco == null)
                return RedirectToAction("Index");

            _context.Servidores.Remove(servidor);
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
