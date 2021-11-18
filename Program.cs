using System;

namespace Series.Classes
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoDoUsuario = ObterOpcaoDoUsuario();

            while (opcaoDoUsuario.ToUpper() != "X")
            {
                switch(opcaoDoUsuario)
                {
                case "1":
                    ListarSerie();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                   AtualizaSerie();
                    break;
                case "4":
                    ExcluiSerie();
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
                
                opcaoDoUsuario = ObterOpcaoDoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nosso serviço.");
            Console.ReadLine();
        }

        private static void ListarSerie(){

            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID {0}:- {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void ExcluiSerie()
        {
            Console.WriteLine("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }


        private static void InserirSerie()
            {
                Console.WriteLine("Inserir uma nova Série");

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("|#{0} - {1}                                |", i, Enum.GetName(typeof(Genero), i));
                    Console.WriteLine("|__________________________________________|");
                }
                Console.WriteLine("_________________________________________");
                Console.WriteLine("|Digite o Genero entre as opções Acima: |");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("|Digite o Titulo da Série:              |");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("|Digite o Ano de inicio da Série:       |");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("|Digite a Descrição da Série:           |");
                Console.WriteLine("|_______________________________________|");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Insere(novaSerie);

            }

            public static void AtualizaSerie()
            {
                Console.WriteLine("Dgite o ID da Série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("|{0} - {1}                                 |", i, Enum.GetName(typeof(Genero), i));
                    Console.WriteLine("|__________________________________________|");
                }
                 Console.WriteLine("_________________________________________");
                Console.WriteLine("|Digite o Genero entre as opções Acima: |");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("|Digite o Titulo da Série:              |");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("|Digite o Ano de inicio da Série:       |");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("|Digite a Descrição da Série:           |");
                Console.WriteLine("|_______________________________________|");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Atualiza(indiceSerie, atualizaSerie);

            }
        

        public static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("_____________________________");
            Console.WriteLine("|#####Series do Campos##### |");
            Console.WriteLine("| Digite a opção desejada:  |");

            Console.WriteLine("|1 - Listar Series          |");
            Console.WriteLine("|2 - Inserir Nova Serie     |");
            Console.WriteLine("|3 - Atualizar Serie        |");
            Console.WriteLine("|4 - Excluir Serie          |");
            Console.WriteLine("|5 - Visualizar Serie       |");
            Console.WriteLine("|C - Limpar a Tela          |");
            Console.WriteLine("|X - Sair                   |");
            Console.WriteLine("|___________________________|");
            Console.WriteLine();

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoDoUsuario;

        }
    }
}
