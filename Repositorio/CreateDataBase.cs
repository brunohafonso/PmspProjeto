using System;
using System.Linq;
using PmspProjeto.Models;

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
                EndLogradouro = "Rua do capitarizinho",
                EndNumero = 33,
                EndComplemento = "Casa 05",
                EndCEP = "04187-160",
                EndBairro = "Vila Liviero",
                RF = "828.720.1",
                Vinculo = 1,
                Cargo = "Auxiliar Técnico de Educação",
                UnidadeLotacao = "Cei Jardim Climax II",
                UnidadeExercicio = "Cei Jardim Climax II"
            };

            context.Servidores.Add(servidor);
            context.SaveChanges();
        }
    }
}