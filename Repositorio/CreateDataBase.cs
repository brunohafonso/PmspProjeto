using System;
using System.Linq;
using PmspProjeto.Models;
using System.Collections.Generic;

namespace PmspProjeto.Repositorio
{
    public class CreateDataBase
    {
        public static void CreateTables(PmspContext context)
        {
            context.Database.EnsureCreated();
            if(context.Servidores.Any())
            {
                return;
            }

             var servidor = new Servidor(){
                Nome = "Bruno Afonso",
                Email = "brunohafonso@gmail.com",
                DataNascimento = DateTime.Parse("25/04/1995"),
                RF = "828.720.1"
            };

            var vinculo = new Vinculo(){
                Vinc = 1,
                Cargo = "Auxiliar Técnico de Educação",
                UnidadeLotacao = "Cei Jardim Climax II",
                UnidadeExercicio = "Cei Jardim Climax II",
                ServidorId = servidor.Id
            };

            var endereco = new Endereco(){
                Logradouro = "Rua do Capitarizinho",
                Numero = 33,
                Complemento = "Casa 05",
                CEP = "04187-160"
            };

            servidor.Endereco = endereco;
            context.Vinculos.Add(vinculo);

            context.Servidores.Add(servidor);
            context.SaveChanges();
        }
    }
}