using System.IO;

namespace TestFiles.Options
{
    public class EntradaOptions
    {
        public string Diretorio { get; set; }
        public string Arquivos { get; set; }
        public string Transacao { get; set; }
        public string ArquivoSaida { get => Path.Combine(Diretorio, "TestFilesOutput.txt"); }
    }
}