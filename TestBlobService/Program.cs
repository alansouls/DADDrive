using BlobServices.Services;
using BlobServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TestBlobService
{
    /// <summary>
    /// Testa o BlobService de acordo com o que foi pedido na atividade
    /// </summary>
    class Program
    {
        //argumentos passados connectionStr atividade3 filesToUpload/file1.bin filesToUpload/file2.tst
        //É necessário setar a working directory para a pasta do projeto, ou passar o caminho relativo correto dos arquivos nos argumentos
        static void Main(string[] args)
        {
            //Lê a string de conexão da conta de armazenamento através do primeiro argumento
            string MyAccountConnectionString = args[0];
            //Inicia o serviço do blob
            IBlobService service = new BlobService(MyAccountConnectionString);

            //Seta o blob com o nome recebido no segundo argumento como ativo
            string blobName = args[1];
            service.SelectBlobContainer(blobName);

            //Lê os dois arquivos
            byte[] file1 =  File.ReadAllBytes(args[2]);
            byte[] file2 = File.ReadAllBytes(args[3]);

            //Faz upload dos arquivos;
            service.UploadFile(file1, args[2]);
            service.UploadFile(file2, args[3]);

            //Lista arquivos
            Console.WriteLine(service.ListFilesString());
        }
    }
}
