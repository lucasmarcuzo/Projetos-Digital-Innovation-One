using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Bank{

	 bool w=false;
	 bool x=false;
	 bool y = false;
	 bool z = false;

	public enum TipoConta
    {
        PessoaFisica = 1, PessoaJuridica = 2	
    }

	public class Conta
	{
		public TipoConta TipoConta { get; set; }
		public double Saldo { get; set; }
		public double Credito { get; set; }
		public string Nome { get; set; }

		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
			return;
		}

		public bool Sacar(double valorSaque)
		{
			Bank classe = new Bank();
			bool x = classe.x;

			if (this.Saldo >= valorSaque){

                this.Saldo -= valorSaque;

            	Console.WriteLine("Novo saldo da conta de {0} é : R$ {1:N2}", this.Nome, this.Saldo);
				Console.WriteLine();
				Console.Write("Digite qualquer tecla para continuar...");
				Console.ReadKey();

            	return true;
            }
			else if (this.Credito <= 0 && this.Saldo <= 0)
			{
				Console.WriteLine("Saldo insuficiente, e você já ultrapassou todo seu limite de crédito!");
				Console.WriteLine();
				Console.Write("Digite qualquer tecla para continuar...");
				Console.ReadKey();

                return false;
			}
            else 
			{
				do
				{ 
					Console.WriteLine("Saldo indisponivel! Deseja retirar o restante do valor do crédito disponível? [s] Sim | [n] Não:");
					string y=Convert.ToString(Console.ReadLine()).ToUpper();

					switch (y)
					{
						case "S":
							if (this.Saldo + this.Credito >= valorSaque)
							{
								this.Saldo -= valorSaque;
								this.Credito += this.Saldo;
								this.Saldo=0;
								Console.WriteLine("Novo saldo da conta de {0} é : R$ {1:N2} | Crédito disponivel: {2:N2}", this.Nome, this.Saldo, this.Credito);
								Console.WriteLine();
								Console.Write("Digite qualquer tecla para continuar...");
								Console.ReadKey();
								return true;
							}
							else
							{
								Console.WriteLine("Valor de crédito indisponivel!");
								Console.WriteLine();
								Console.Write("Digite qualquer tecla para continuar...");
								Console.ReadKey();
								return false;
							}
						case "N":
							break;
						default:
							Console.WriteLine("VALOR INÁLIDO!: Digite \"s\" para SIM ou \"n\" para NÃO!"); 
							Console.WriteLine();
							Console.Write("Digite qualquer tecla para continuar...");
							Console.ReadKey();
							x=false;
							return false;
					}
					
				} while (x==false);

				return true;

            }
			   
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Novo saldo da conta de {0} é : R$ {1:N2}", this.Nome, this.Saldo);
			Console.WriteLine();
			Console.Write("Digite qualquer tecla para continuar...");
			Console.ReadKey();
			
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia) == true){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Tipo da Conta: " + this.TipoConta + " | ";
            retorno += "Cliente: " + this.Nome + " | ";
            retorno += "Saldo: R$ " + this.Saldo.ToString("N2") + " | ";
            retorno += "Crédito disponível: R$ " + this.Credito.ToString("N2");
			return retorno;
		}

		public static string Error_OpcaoDesejada(string tratar_erro)
		{   
			if (!Regex.IsMatch(tratar_erro, @"^[ 1-6 C X]*$") )
			{
				throw new Exception("Digite um valor válido!"); 
			}
			return tratar_erro;

		}   
		public static string Error_NumeroConta(string veri_indiceConta)
		{
			if (!Regex.IsMatch(veri_indiceConta, @"^[ 0-9 ]*$") )
			{
				throw new Exception("Digite um valor válido!"); 
			}
			return veri_indiceConta;
			
		}

		public static string Error_Valor(string veri_valorDeposito)
		{
			if (!Regex.IsMatch(veri_valorDeposito, @"^[ 0-9 . ,]*$") )
			{
				throw new Exception("Digite um valor válido!"); 
			}
			return veri_valorDeposito;
			
		}

		public static string Error_TipoConta(string veri_entradaTipoConta)
		{
			if (!Regex.IsMatch(veri_entradaTipoConta, @"^[ 1-2 ]*$") )
			{
				throw new Exception("Digite um valor válido!"); 
			}
			return veri_entradaTipoConta;
			
		}

		public static string Error_Nome(string veri_name)
   		{
        if (!Regex.IsMatch(veri_name, @"^[ a-zA-Z á]*$"))
        { 
            throw new Exception("O nome digitado não pode conter números ou caracteres especiais!"); 
        }
        return veri_name; 
    	}

	}


	class Program
	{
		static List<Conta> listContas = new List<Conta>();
		static void Main(string[] args)
		{
			Bank classe = new Bank();
			bool x = classe.x;

			do
			{
				Console.WriteLine();
				Console.WriteLine("Olá, seja bem-vindo ao MarBank!!!");
				Console.WriteLine();
				Console.WriteLine("1- Listar contas");
				Console.WriteLine("2- Abrir nova conta");
				Console.WriteLine("3- Transferir");
				Console.WriteLine("4- Sacar");
				Console.WriteLine("5- Depositar");
				Console.WriteLine("6- Encerrar uma conta");
				Console.WriteLine();
				Console.WriteLine("C- Limpar a Tela");
				Console.WriteLine("X- Sair");
				Console.WriteLine();
				Console.Write("Informe a opção desejada: ");
				 
				try
				{
					string opcaoUsuario = Console.ReadLine().ToUpper();
					Conta.Error_OpcaoDesejada(opcaoUsuario);

					switch (opcaoUsuario)
					{
						case "1":
							ListarContas();
							break;
						case "2":
							InserirConta();
							break;
						case "3":
							Transferir();
							break;
						case "4":
							Sacar();
							break;
						case "5":
							Depositar();
							break;
						case "6":
							Fechar();
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

		private static void Fechar()
		{
			Bank classe = new Bank();
			bool x = classe.x;

			do
			{
				string tipodeconta="";

				do
				{
					Console.WriteLine("Qual o tipo da conta?");
					Console.WriteLine("Digite 1 - Para fechar uma Conta Fisica"); 
					Console.WriteLine("Digite 2 - Para fechar uma Conta Juridica");

					tipodeconta=Console.ReadLine(); 

					switch (tipodeconta)
					{
						case "1":
							tipodeconta="PessoaFisica";
							x=true;
							break;
						case "2":
							tipodeconta="PessoaJuridica";
							x=true;
							break;
						default:
							Console.WriteLine("VALOR INÁLIDO!: Digite \"1\" para CONTA FISICA ou \"2\" para CONTA JURIDICA!");
							Console.WriteLine();
							Console.Write("Digite qualquer tecla para continuar...");
							Console.ReadKey();
							x=false;
							break;
					}

				} while (x==false);
				
				Console.WriteLine("Digite 1 - Se deseja fechar com o número da conta"); 
				Console.WriteLine("Digite 2 - Se deseja fechar com o nome do titular da conta");
				string tipofechar=Convert.ToString(Console.ReadLine());

				switch (tipofechar)
				{
					case "1":
					Console.Write("Digite o número da conta: ");
					int apagarconta_numero=Convert.ToInt32(Console.ReadLine());

					for (int i = 0; i < listContas.Count; i++)
					{
						Conta conta = listContas[i];

						if (i == apagarconta_numero && conta.TipoConta.ToString() == tipodeconta)
						{
							Console.Write("Conta encontrada: #{0} - ", i);
							Console.WriteLine(conta);

							if(conta.Saldo == 0f)
							{
								Console.Write("Deseja realmente encerrar a conta? [s] Sim | [n] Não: ");
								string confirm=Console.ReadLine();

								switch (confirm)
								{
									case "s":
										listContas.RemoveAt(i);
										Console.WriteLine("Conta encerrada com sucesso, obrigado!");
										Console.WriteLine();
										Console.Write("Digite qualquer tecla para continuar...");
										Console.ReadKey();
										x=true;
										break;

									case "n":
										x=true;
										break;

									default:
										Console.WriteLine("VALOR INÁLIDO!: Digite \"s\" para SIM ou \"n\" para NÃO!"); 
										Console.WriteLine();
										Console.Write("Digite qualquer tecla para continuar...");
										Console.ReadKey();
										x=false;
										break;
								}
							}
							else if (conta.Saldo < 0f)
							{
								Console.WriteLine();
								Console.WriteLine("ERRO: Existem valores pendentes de pagamento nesta conta, quite os valores para prosseguir com o cancelamento!");
								Console.WriteLine();
								Console.Write("Digite qualquer tecla para continuar...");
								Console.ReadKey();
								x=true;
							}
							else if (conta.Saldo > 0f)
							{
								Console.WriteLine();
								Console.WriteLine("Existe saldo positivo nesta conta, faça uma retirada antes de prosseguir com o cancelamento!");
								Console.WriteLine();
								Console.Write("Digite qualquer tecla para continuar...");
								Console.ReadKey();
								x=true;
							}
						}
						else 
						{
							Console.WriteLine("Número de conta do cliente não foi encontrado, tente novamente!");
							Console.WriteLine();
							Console.Write("Digite qualquer tecla para continuar...");
							Console.ReadKey();
							x=false;
							break;
						}
					}
					break;

					case "2":
					Console.Write("Digite o nome do cliente: ");
					var apagarconta_nome=Console.ReadLine();

					for (int i = 0; i < listContas.Count; i++)
					{
						Conta conta = listContas[i];
						
						if (conta.Nome == apagarconta_nome && conta.TipoConta.ToString() == tipodeconta)
						{
							Console.Write("Conta encontrada: #{0} - ", i);
							Console.WriteLine(conta);

							if(conta.Saldo == 0f)
							{
								Console.Write("Deseja realmente encerrar a conta? [s] Sim | [n] Não: ");
								string confirm=Console.ReadLine();

								switch (confirm)
								{
									case "s":
										listContas.RemoveAt(i);
										Console.WriteLine("Conta encerrada com sucesso, obrigado!");
										Console.WriteLine();
										Console.Write("Digite qualquer tecla para continuar...");
										Console.ReadKey();
										x=true;
										break;
									case "n":
										x=true;
										break;
									default:
										Console.WriteLine("VALOR INÁLIDO!: Digite \"s\" para SIM ou \"n\" para NÃO!"); 
										Console.WriteLine();
										Console.Write("Digite qualquer tecla para continuar...");
										Console.ReadKey();
										x=false;
										break;
								}
							}
							else if (conta.Saldo < 0f)
							{
								Console.WriteLine();
								Console.WriteLine("ERRO: Existem valores pendentes de pagamento nesta conta, quite os valores para prosseguir com o cancelamento!");
								Console.WriteLine();
								Console.Write("Digite qualquer tecla para continuar...");
								Console.ReadKey();
								x=true;
								break;
							}
							else if (conta.Saldo > 0f)
							{
								Console.WriteLine();
								Console.WriteLine("Existe saldo positivo nesta conta, faça uma retirada antes de prosseguir com o cancelamento!");
								Console.WriteLine();
								Console.Write("Digite qualquer tecla para continuar...");
								Console.ReadKey();
								x=true;
								break;
							}
						}
						else 
						{
							Console.WriteLine("Nome do cliente não foi encontrado, tente novamente!");
							Console.WriteLine();
							Console.Write("Digite qualquer tecla para continuar...");
							Console.ReadKey();
							x=false;
							break;
						}
					}
					break;
				}
				
			} while (x==false);
		}

		private static void Depositar()
		{
			Bank classe = new Bank();
			bool x = classe.x;	
			bool y = classe.y;

			string veri_indiceConta="";
			string veri_valorDeposito="";
			
			do
			{
				Console.Write("Digite o número da conta: ");
				veri_indiceConta = Console.ReadLine();
				
				try
				{
					Conta.Error_NumeroConta(veri_indiceConta);
					x=true;
					
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();

				}

			}while(x==false);	

			do
			{
				Console.Write("Digite o valor a ser depositado: ");
				veri_valorDeposito = Console.ReadLine();

				try
				{
					Conta.Error_Valor(veri_valorDeposito);
					y=true;
					
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();

				}

			}while(y==false);
		

			int indiceConta=Int32.Parse(veri_indiceConta);
			double valorDeposito=Double.Parse(veri_valorDeposito);

            listContas[indiceConta].Depositar(valorDeposito);
		}

		private static void Sacar()
		{
			Bank classe = new Bank();
			bool x = classe.x;	
			bool y = classe.y;

			string veri_indiceConta="";
			string veri_valorSaque="";
				
			do
			{
				Console.Write("Digite o número da conta: ");
				veri_indiceConta = Console.ReadLine();
				
				try
				{
					Conta.Error_NumeroConta(veri_indiceConta);
					x=true;
					
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();

				}

			}while(x==false);
		
			do
			{

				Console.Write("Digite o valor a ser sacado: ");
				veri_valorSaque = Console.ReadLine();

				try
				{
					Conta.Error_Valor(veri_valorSaque);
					y=true;
					
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();

				}

			}while(y==false);

			int indiceConta=Int32.Parse(veri_indiceConta);
			double valorSaque=Double.Parse(veri_valorSaque);

            listContas[indiceConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{	
			Bank classe = new Bank();
			bool x = classe.x;	
			bool y = classe.y;
			bool z = classe.z;

			string veri_indiceContaOrigem="";
			string veri_indiceContaDestino="";
			string veri_valorTransferencia="";
					
			do
			{
				Console.Write("Digite o número da conta de origem: ");
				veri_indiceContaOrigem = Console.ReadLine();
				
				try
				{
					Conta.Error_NumeroConta(veri_indiceContaOrigem);
					x=true;
					
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();

				}

			}while (x==false);

			do
			{
				Console.Write("Digite o número da conta de destino: ");
				veri_indiceContaDestino = Console.ReadLine();

				try
				{
					Conta.Error_NumeroConta(veri_indiceContaDestino);
					y=true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();
				}

			}while (y==false);

			do
			{
				Console.Write("Digite o valor a ser transferido: ");
				veri_valorTransferencia=Console.ReadLine();

				try
				{
					Conta.Error_Valor(veri_valorTransferencia);
					z=true;
					
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();

				}

			}while (z==false);

			int indiceContaOrigem=Int32.Parse(veri_indiceContaOrigem);
			int indiceContaDestino=Int32.Parse(veri_indiceContaDestino);
			double valorTransferencia=Double.Parse(veri_valorTransferencia);
            
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

		private static void InserirConta()
		{
			Bank classe = new Bank();
			bool w = classe.w;
			bool x = classe.x;	
			bool y = classe.y;
			bool z = classe.z;

			string veri_entradaTipoConta="";
			string entradaNome="";
			string veri_entradaSaldo="";
			string veri_entradaCredito="";

			do
			{
				Console.Clear();
				Console.WriteLine("Qual a conta que deseja abrir?:");
				Console.WriteLine();
				Console.WriteLine("Digite 1 - Para Conta Fisica"); 
				Console.WriteLine("Digite 2 - Para Conta Juridica");
				Console.WriteLine();
				veri_entradaTipoConta = Console.ReadLine();

				try
				{
					Conta.Error_TipoConta(veri_entradaTipoConta);
					w=true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();
				}

			} while (w==false);

			do
			{	
				Console.Write("Digite o Nome do Cliente: ");
				entradaNome = Console.ReadLine();

				try
				{
					Conta.Error_Nome(entradaNome);
					x=true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();
				}
			
			} while (x==false);
			
			do
			{
				Console.Write("Digite o saldo inicial: ");
				veri_entradaSaldo = Console.ReadLine();

				try
				{
					Conta.Error_Valor(veri_entradaSaldo);
					y=true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();
				}

			} while (y==false);

			do
			{

				Console.Write("Digite o crédito: ");
				veri_entradaCredito = Console.ReadLine();

				try
				{
					Conta.Error_Valor(veri_entradaCredito);
					z=true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERRO: {0}",ex.Message);
					Console.WriteLine();
					Console.Write("Digite qualquer tecla para continuar...");
					Console.ReadKey();
				}

			} while (z==false);
					

				int entradaTipoConta=Int32.Parse(veri_entradaTipoConta);
				double entradaSaldo=double.Parse(veri_entradaSaldo);
				double entradaCredito=double.Parse(veri_entradaCredito);

				Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
														saldo: entradaSaldo,
														credito: entradaCredito,
														nome: entradaNome);

				listContas.Add(novaConta);

				Console.Clear();

		}

		private static void ListarContas()
		{

			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				Console.WriteLine();
				Console.Write("Digite qualquer tecla para continuar...");
				Console.ReadKey();
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
				
			}

			Console.WriteLine();
			Console.Write("Digite qualquer tecla para continuar...");
			Console.ReadKey();
		}

	}

}
