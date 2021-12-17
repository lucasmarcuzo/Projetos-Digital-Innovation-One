import java.io.IOException;
import java.util.concurrent.TimeUnit;

public class Main extends Ferramentas{

    private static boolean validarAbrirConta = true;
    private static boolean validTipoContaCorrente = true;
    private static boolean validTipoContaPoupanca = true;

    private static int clienteSequencial = 1;
    private static int contaCorrenteSequencial = 1;
    private static int contaPoupancaSequencial = 1;

    public static void main(String[] args) throws InterruptedException, IOException {
        limparTela();
        System.out.println("Olá, seja muito bem-vindo(a)! \n");
        carregandoTela();

        Inicio();
    }

    public static void Inicio() throws InterruptedException, IOException {
        while (validarAbrirConta) {
            limparTela();
            System.out.print("Qual o tipo da Conta você deseja abrir? \n" +
                    "\n1 - Conta Corrente " +
                    "\n2 - Conta Poupança " +
                    "\n3 - Sair\n\n");
            int AbrirTipoConta = scannerInt();
            switch (AbrirTipoConta){
                case 1 -> {
                    //Conta corrente
                    while(validTipoContaCorrente){
                        limparTela();
                        System.out.print("Digite seu nome completo: ");
                        String nomeCliente = scannerString();
                        if(!nomeCliente.matches("[0-9]+")){
                            clienteSequencial++;
                            contaCorrenteSequencial++;
                            Cliente.getListaClientes().add(new Cliente(nomeCliente));
                            Conta.getListaContasCorrente().add(new ContaCorrente(Cliente.getListaClientes().get(Cliente.getListaClientes().size()-1)));

                            limparTela();
                            System.out.printf("Parabéns %s sua conta Corrente foi criada com sucesso!\n\n", nomeCliente);
                            Conta.getListaContasCorrente().get(Conta.getListaContasCorrente().size()-1).imprimirExtrato();
                            System.out.println("\n\nPressione qualquer tecla para continuar...");
                            System.in.read();
                            limparTela();
                            System.out.print("Deseja abrir uma nova conta? \n1 - S\n2 - N\n\n");
                            int ver = scannerInt();
                            if (ver == 1){
                                validarAbrirConta = true;
                                break;
                            }
                            else{
                                validarAbrirConta = false;
                                validTipoContaCorrente = false;
                                OpcoesContas.opcoesConta(true);
                                break;
                            }
                        }
                        else{
                            limparTela();
                            System.err.println("Tipo de dados inserido é inválido, insira somente letras!\n");
                            System.err.println("Pressione qualquer tecla para continuar...");
                            System.in.read();
                            limparTela();
                        }
                    }
                }
                case 2 -> {
                    //Conta Poupança
                    while(validTipoContaPoupanca) {
                        limparTela();
                        System.out.print("Digite seu nome completo: ");
                        String nomeCliente = scannerString();
                        if (!nomeCliente.matches("[0-9]+")) {
                            clienteSequencial++;
                            contaPoupancaSequencial++;
                            Cliente.getListaClientes().add(new Cliente(nomeCliente));
                            Conta.getListaContasPoupanca().add(new ContaPoupanca(Cliente.getListaClientes().get(Cliente.getListaClientes().size()-1)));

                            limparTela();
                            System.out.printf("Parabéns %s sua conta Poupança foi criada com sucesso!\n\n", nomeCliente);
                            Conta.getListaContasPoupanca().get(Conta.getListaContasPoupanca().size()-1).imprimirExtrato();
                            System.out.println("\n\nPressione qualquer tecla para continuar...");
                            System.in.read();
                            limparTela();
                            System.out.print("Deseja abrir uma nova conta? \n1 - S\n2 - N\n\n");
                            int ver = scannerInt();
                            if (ver == 1){
                                validarAbrirConta = true;
                                break;
                            }
                            else{
                                validarAbrirConta = false;
                                validTipoContaPoupanca = false;
                                OpcoesContas.opcoesConta(true);
                                break;
                            }
                        } else {
                            limparTela();
                            System.err.println("Tipo de dados inserido é inválido, insira somente letras!\n");
                            System.err.println("Pressione qualquer tecla para continuar...");
                            System.in.read();
                            limparTela();
                        }
                    }
                }
                case 3 -> {
                    sair();
                }
                default -> {
                    limparTela();
                    System.out.print("Valor inválido, digite um valor entre 1 e 3!\n");
                    TimeUnit.SECONDS.sleep(2);
                    validarAbrirConta = true;
                }
            }
        }
    }



}
