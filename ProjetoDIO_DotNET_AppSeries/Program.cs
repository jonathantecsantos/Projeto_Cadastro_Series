using ProjetoDIO_DotNET_AppSeries.Class;
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
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
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
            repositorio.Inserir(dadosSerie());
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Código/ID da Série: ");
            int codigoSerie = int.Parse(Console.ReadLine());
            
            repositorio.Atualizar(codigoSerie, dadosSerie());
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("Informe o código da Série a ser excluído: ");
            int codigoSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(codigoSerie);
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Informe o código da Série a ser exibido:");
            int codigoSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(codigoSerie);
            Console.WriteLine(serie);
        }

        //Solicita os dados do usuario, utilizado nos metodos de criar e atualizar
        public static Serie dadosSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o título da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Informe o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);
            return serie;
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" APLICAÇÃO DE CADASTRO DE SÉRIES");
            Console.WriteLine(" ----- ESCOLHA UMA DAS OPÇÕES ABAIXO: ----- ");
            Console.WriteLine("1 - Listar séries por código de cadastro");
            Console.WriteLine("2 - Cadastrar nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string entradaUsuario = Console.ReadLine().ToUpper();

            return entradaUsuario;
        }
    }
}
