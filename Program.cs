using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PmspProjeto.Repositorio;

namespace PmspProjeto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ambiente = BuildWebHost(args);
            using(var escopo = ambiente.Services.CreateScope()) {
                var servico = escopo.ServiceProvider;
                try
                {
                    var contexto = servico.GetRequiredService<PmspContext>();
                    CreateDataBase.CreateTables(contexto);
                } 
                catch(Exception ex) 
                {
                    var saida = servico.GetService<ILogger<Program>>();
                    saida.LogError(ex.Message, "Erro a criar banco de dados");
                }
            }
            ambiente.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
