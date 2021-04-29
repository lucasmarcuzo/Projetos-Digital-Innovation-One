using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Projeto___Criando_um_APP_simples_de_cadastro_de_séries_em_.NET
{
    namespace DIO.Series
    {
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }

    public enum Genero
    {
        Acao = 1,
        Aventura = 2,
        Comedia = 3,
        Documentario = 4,
        Drama = 5,
        Espionagem = 6,
        Faroeste = 7,
        Fantasia = 8,
        Ficcao_Cientifica = 9,
        Musical = 10,
        Romance = 11,
        Suspense = 12,
        Terror = 13
    }

    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }

        public static string Error_OpcaoDesejada(string tratar_erro)
        {   
            if (!Regex.IsMatch(tratar_erro, @"^[ 1-5 C X]*$") )
            {
                throw new Exception("Digite um valor válido!"); 
            }
            return tratar_erro;

        }  

        public static string Error_indiceSerie(string veri_indiceserie)
        {   
            if (!Regex.IsMatch(veri_indiceserie, @"^[ 1-9 ]*$") )
            {
                throw new Exception("Digite um valor válido!"); 
            }
            return veri_indiceserie;

        }  

        public static string Error_generoSerie(string veri_generoSerie)
        {   
            if (!Regex.IsMatch(veri_generoSerie, @"^[ 1-13 ]*$") )
            {
                throw new Exception("Digite um valor entre 1 e 13!"); 
            }
            return veri_generoSerie;

        }  

        public static string Error_Titulo(string veri_name)
        {
            if (veri_name.Length <= 1)
            { 
                throw new Exception("O nome deve ter mais de um caractere!"); 
            }
            return veri_name; 
        }

        public static string Error_Ano(string veri_entradaAno)
        {
            if (veri_entradaAno.Length!= 4)
            { 
                throw new Exception("A data deve ter 4 caracteres! EX: 2010"); 
            }
            if (!Regex.IsMatch(veri_entradaAno, @"^[ 0000-9999 ]*$") )
            {
                throw new Exception("Digite um valor válido!"); 
            }
            return veri_entradaAno; 
        }

        public static string Error_Descricao(string veri_descricao)
        {
            if (veri_descricao.Length <= 1)
            { 
                throw new Exception("A descrição deve ter mais de um caractere!"); 
            }
            return veri_descricao; 
        }

    }
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }

    }
    public class Serie : EntidadeBase
    {
        
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir() {

            this.Excluido = true;
        }
        
    }

    class Program
    {
        bool v=false;
        bool w=false;
        bool x=false;
        bool y = false;
        bool z = false;
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Program classe = new Program();
            bool x = classe.x;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Bem-vindo ao MarcuzoSéries!");
                Console.WriteLine();
                Console.WriteLine("1- Listar séries");
                Console.WriteLine("2- Inserir uma nova série");
                Console.WriteLine("3- Atualizar série");
                Console.WriteLine("4- Excluir série");
                Console.WriteLine("5- Visualizar série");
                Console.WriteLine();
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();
                Console.Write("Informe a opção desejada: ");
            
                try
                {
                    string opcaoUsuario = Console.ReadLine().ToUpper();
                    SerieRepositorio.Error_OpcaoDesejada(opcaoUsuario);

                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
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
                        case "X":
                            Console.WriteLine("Obrigado por utilizar nossos serviços!");
                            x=true;
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.WriteLine();
                    Console.Write("Digite qualquer tecla para continuar...");
                    Console.ReadKey();
                    
                }
            
            } while (x==false);
            
        }

        private static void ExcluirSerie()
        {
            Program classe = new Program();
            bool x = classe.x;

            string veri_indiceserie="";

            do
            {
                Console.Write("Digite o ID da série: ");
                veri_indiceserie = Console.ReadLine();
                
                try
                {
                    SerieRepositorio.Error_indiceSerie(veri_indiceserie);
                    x=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (x==false);

            int indiceSerie=Convert.ToInt32(veri_indiceserie);
            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Program classe = new Program();
            bool x = classe.x;

            string veri_indiceserie="";

            do
            {
                Console.Write("Digite o id da série: ");
                veri_indiceserie = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_indiceSerie(veri_indiceserie);
                    x=true;
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (x==false);

            int indiceSerie=Convert.ToInt32(veri_indiceserie);
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Program classe = new Program();
            bool v = classe.v;
            bool w = classe.w;
            bool x = classe.x;
            bool y = classe.y;
            bool z = classe.z;

            string veri_indiceserie="";
            string veri_entradaGenero="";
            string veri_entradaTitulo="";
            string veri_entradaAno="";
            string veri_entradaDescricao="";

            do
            {
                Console.Write("Digite o ID da série: ");
                veri_indiceserie = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_indiceSerie(veri_indiceserie);
                    v=true;
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (v==false);


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            do
            {
                Console.Write("Qual o gênero da série: ");
                veri_entradaGenero = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_generoSerie(veri_entradaGenero);
                    w=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (w==false);

            do
            {
                Console.Write("Digite o Título da Série: ");
                veri_entradaTitulo = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_Titulo(veri_entradaTitulo);
                    x=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (x==false);
        
            do
            {
                Console.Write("Digite o Ano de Início da Série: ");
                veri_entradaAno = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_Ano(veri_entradaAno);
                    y=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    
                }
                
            } while (y==false);

            do
            {
                Console.Write("Digite a Descrição da Série: ");
                veri_entradaDescricao = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_Descricao(veri_entradaDescricao);
                    z=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (z==false);

            int indiceSerie=Convert.ToInt32(veri_indiceserie);
            int entradaGenero=Convert.ToInt32(veri_entradaGenero);
            string entradaTitulo=Convert.ToString(veri_entradaTitulo);
            int entradaAno=Convert.ToInt32(veri_entradaAno);
            string entradaDescricao=Convert.ToString(veri_entradaDescricao);

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                Console.ReadKey();
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }

            Console.ReadKey();
        }

        private static void InserirSerie()
        {
            Program classe = new Program();
            bool v = classe.v;
            bool w = classe.w;
            bool x = classe.x;
            bool y = classe.y;
            bool z = classe.z;

            string veri_entradaGenero="";
            string veri_entradaTitulo="";
            string veri_entradaAno="";
            string veri_entradaDescricao="";

            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            do
            {
                Console.Write("Digite o gênero entre as opções acima: ");
                veri_entradaGenero = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_generoSerie(veri_entradaGenero);
                    w=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (w==false);

            do
            {
                Console.Write("Digite o Título da Série: ");
                veri_entradaTitulo = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_Titulo(veri_entradaTitulo);
                    x=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                }
                
            } while (x==false);

            do
            {
                Console.Write("Digite o Ano de Início da Série: ");
                veri_entradaAno = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_Ano(veri_entradaAno);
                    y=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    
                }
                
            } while (y==false);

            do
            {
                Console.Write("Digite a Descrição da Série: ");
                veri_entradaDescricao = Console.ReadLine();

                try
                {
                    SerieRepositorio.Error_Descricao(veri_entradaDescricao);
                    z=true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: {0}",ex.Message);
                    Console.ReadKey();
                    
                }
                
            } while (z==false);

            int entradaGenero=Convert.ToInt32(veri_entradaGenero);
            string entradaTitulo=Convert.ToString(veri_entradaTitulo);
            int entradaAno=Convert.ToInt32(veri_entradaAno);
            string entradaDescricao=Convert.ToString(veri_entradaDescricao);

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

    }
    }

}
