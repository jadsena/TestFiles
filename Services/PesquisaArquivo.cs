using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestFiles.Options;

namespace TestFiles.Services
{
    public class PesquisaArquivo
    {
        private readonly ILogger<PesquisaArquivo> _logger;
        private readonly EntradaOptions _options;
        public PesquisaArquivo(ILogger<PesquisaArquivo> logger, IOptions<EntradaOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }
        public void Run()
        {
            _logger.LogInformation($"Pesquisando a transação [{_options.Transacao}] no diretório [{_options.Diretorio}]");
            var files = Directory.GetFiles(_options.Diretorio, _options.Arquivos);
            StringBuilder sb = new StringBuilder();
            foreach (var filename in files)
            {
                _logger.LogInformation(filename);
                using(StreamReader sr = new StreamReader(filename))
                {
                    var content = sr.ReadToEnd();
                    Regex regex = new Regex($".*{_options.Transacao}.*");
                    foreach (Match match in regex.Matches(content))
                    {
                        string line = match.Value.Replace(Environment.NewLine, "").Replace('\r',' ');
                        sb.AppendLine(line);
                    }
                }
            }
            using(StreamWriter sw = new StreamWriter(_options.ArquivoSaida))
            {
                sw.Write(sb.ToString());
                sw.Flush();
            }
            _logger.LogInformation("Sucesso!!!");
        }
    }
}