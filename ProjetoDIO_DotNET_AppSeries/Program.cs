using ProjetoDIO_DotNET_AppSeries.Class;
using ProjetoDIO_DotNET_AppSeries.Enum;
using System;

namespace ProjetoDIO_DotNET_AppSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeriesCodigo();
                        break;
                    //case "2":
                    // ListarSeriesOrdemAlfabetica();
                    case "3":
                        InserirSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine();
            Console.WriteLine("Processamento finalizado");
            Console.ReadLine();
        }

        private static void ListarSeriesCodigo()
        {
            Console.WriteLine("Lista de séries: ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado!");
                return;
            }
            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" APLICAÇÃO DE CADASTRO DE SÉRIES");
            Console.WriteLine(" ----- ESCOLHA UMA DAS OPÇÕES ABAIXO: ----- ");
            Console.WriteLine("1 - Listar séries por código de cadastro");
            Console.WriteLine("2 - Visualizar série por ordem alfabética");
            Console.WriteLine("3 - Cadastrar nova série");
            Console.WriteLine("4 - Atualizar série");
            Console.WriteLine("5 - Excluir série");
            Console.WriteLine("6 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string entradaUsuario = Console.ReadLine().ToUpper();

            return entradaUsuario;
        }
    }
}
