using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TestFiles.Options;
using TestFiles.Services;

namespace TestFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine("Uso:");
                Console.WriteLine("     TestFiles <path> <files> <transaction>");
                Console.WriteLine("           <files> = Nome(s) do(s) arquivos(s), aceita carcateres curinga (*)");
                return;
            }
            else if (!Directory.Exists(args[0]))
            {
                Console.WriteLine($"Diretório [{args[0]}] não encontrado.");
                return;
            }
            ServiceCollection services = new ServiceCollection();
            ConfigureService(services, args);

            var provider = services.BuildServiceProvider();

            var pesquisa = provider.GetService<PesquisaArquivo>();

            pesquisa.Run();
        }

        static void ConfigureService(IServiceCollection services, string[] args)
        {
            services.AddLogging(builder => 
            {
                builder.AddConsole();
            });
            services.Configure<EntradaOptions>(opt =>
            {
                opt.Transacao = args[2];
                opt.Arquivos = args[1];
                opt.Diretorio = args[0];
            });
            services.AddTransient<PesquisaArquivo>();
        }
    }
}
