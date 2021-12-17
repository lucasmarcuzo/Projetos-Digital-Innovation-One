import java.io.IOException;
import java.util.concurrent.TimeUnit;

public class OpcoesContas extends Ferramentas {

    private static boolean validOpcoesConta = true;

    public static void opcoesConta(boolean escolhaOpcaoConta) throws InterruptedException, IOException {

        validOpcoesConta = escolhaOpcaoConta;
        while (validOpcoesConta){
            limparTela();
            System.out.print("Escolha uma opção a seguir: \n" +
                    "\n1 - Ver extrato " +
                    "\n2 - Sacar " +
                    "\n3 - Depositar " +
                    "\n4 - Transferir " +
                    "\n5 - Fechar uma Conta " +
                    "\n6 - Sair\n\n");

            int opcaoConta = scannerInt();
            switch (opcaoConta){

                case 1: //Extrato
                    limparTela();
                    System.out.println("Qual o tipo da Conta? \n1 - CORRENTE\n2 - POUPANÇA\n\n");
                    int numTipoExtrato = scannerInt();

                    System.out.print("Digite o número da conta: ");
                    int numContaExtrato = scannerInt();

                    if (numTipoExtrato == 1){
                        for (var item : Conta.getListaContasCorrente()) {
                            if(item.getNumero() == numContaExtrato){
                                carregandoTela();
                                limparTela();
                                item.imprimirExtrato();
                                break;
                            }
                        }
                    }else if (numTipoExtrato == 2){
                        for (var item : Conta.getListaContasPoupanca()) {
                            if(item.getNumero() == numContaExtrato){
                                carregandoTela();
                                limparTela();
                                item.imprimirExtrato();
                                break;
                            }
                        }
                    }
                    validOpcoesConta = false;
                    break;

                case 2: //Sacar
                    limparTela();
                    System.out.println("Qual o tipo da Conta? \n1 - CORRENTE\n2 - POUPANÇA\n\n");
                    int numTipoSacar = scannerInt();

                    System.out.print("Digite o número da conta: ");
                    int numContaSacar = scannerInt();

                    if (numTipoSacar == 1){
                        for (var item : Conta.getListaContasCorrente()) {
                            if(item.getNumero() == numContaSacar){
                                System.out.print("Digite o valor do saque em R$: ");
                                double valorSaque = scannerDouble();
                                if(item.saldo < valorSaque){
                                    System.out.printf("O valor do saque é menor que o saldo disponivel em conta, saldo disponivel: %.2f\n", item.saldo);
                                    System.err.println("Pressione qualquer tecla para continuar...");
                                    System.in.read();
                                    limparTela();
                                    opcoesConta(true);
                                }else{
                                    carregandoTela();
                                    limparTela();
                                    item.sacar(valorSaque);
                                    System.out.printf("\n\n%.2f foi sacado com sucesso da conta: %d\n\n",valorSaque, item.getNumero());
                                    item.imprimirExtrato();
                                    break;
                                }
                            }
                        }
                    }else if (numTipoSacar == 2){
                        for (var item : Conta.getListaContasPoupanca()) {
                            if(item.getNumero() == numContaSacar){
                                System.out.print("Digite o valor do saque em R$: ");
                                double valorSaque = scannerDouble();
                                if(item.saldo < valorSaque){
                                    System.out.printf("O valor do saque é menor que o saldo disponivel em conta, saldo disponivel: %.2f\n", item.saldo);
                                    System.err.println("Pressione qualquer tecla para continuar...");
                                    System.in.read();
                                    limparTela();
                                    opcoesConta(true);
                                }else{
                                    carregandoTela();
                                    limparTela();
                                    item.sacar(valorSaque);
                                    System.out.printf("\n\n%.2f foi sacado com sucesso da conta: %d\n\n",valorSaque, item.getNumero());
                                    item.imprimirExtrato();
                                    break;
                                }
                            }
                        }
                    }
                    validOpcoesConta = false;
                    break;

                case 3: //Deposito
                    limparTela();
                    System.out.println("Qual o tipo da Conta? \n1 - CORRENTE\n2 - POUPANÇA\n\n");
                    int numTipoDeposito = scannerInt();

                    System.out.print("Digite o número da conta: ");
                    int numContaDeposito = scannerInt();

                    if (numTipoDeposito == 1){
                        for (var item : Conta.getListaContasCorrente()) {
                            if(item.getNumero() == numContaDeposito){
                                System.out.print("Digite o valor do depósito em R$: ");
                                double valorDeposito = scannerDouble();
                                item.depositar(valorDeposito);
                                carregandoTela();
                                limparTela();
                                System.out.printf("\n\n%.2f foi depositado com sucesso na conta: %d\n\n",valorDeposito, item.getNumero());
                                item.imprimirExtrato();
                                break;
                            }
                        }
                    }else if (numTipoDeposito == 2){
                        for (var item : Conta.getListaContasPoupanca()) {
                            if(item.getNumero() == numContaDeposito){
                                System.out.print("Digite o valor do depósito em R$: ");
                                double valorDeposito = scannerDouble();
                                item.depositar(valorDeposito);
                                limparTela();
                                carregandoTela();
                                limparTela();
                                System.out.printf("\n\n%.2f foi depositado com sucesso na conta: %d\n\n",valorDeposito, item.getNumero());
                                item.imprimirExtrato();
                                break;
                            }
                        }
                    }
                    validOpcoesConta = false;
                    break;

                case 4: //Transferencia
                    limparTela();
                    System.out.println("Qual o tipo da Conta de Origem? \n1 - CORRENTE\n2 - POUPANÇA\n\n");
                    int numTipoOrigem = scannerInt();
                    System.out.print("Digite o número da conta de origem: ");
                    int numContaOrigem = scannerInt();

                    System.out.println("Qual o tipo da Conta de Destino? \n1 - CORRENTE\n2 - POUPANÇA\n\n");
                    int numTipoDestino = scannerInt();
                    System.out.print("Digite o número da conta de destino: ");
                    int numContaDestino = scannerInt();

                    if (numTipoOrigem == 1){
                        for (var itemOrigem : Conta.getListaContasCorrente()) {
                            if(itemOrigem.getNumero() == numContaOrigem){
                                if(numTipoDestino == 1){
                                    for (var itemDestino : Conta.getListaContasCorrente()) {
                                        if(itemDestino.getNumero() == numContaDestino){
                                            System.out.print("Digite o valor da transferencia em R$: ");
                                            double valorTransferencia = scannerDouble();
                                            itemOrigem.transferir(valorTransferencia, itemDestino);
                                            carregandoTela();
                                            limparTela();
                                            System.out.printf("\n\n%.2f foi transferido com sucesso da conta: %d para a conta: %d\n\n",valorTransferencia, itemOrigem.getNumero(), itemDestino.getNumero());
                                            itemOrigem.imprimirExtrato();
                                        }
                                    }
                                }else if(numTipoDestino == 2){
                                    for (var itemDestino : Conta.getListaContasPoupanca()) {
                                        if(itemDestino.getNumero() == numContaDestino){
                                            System.out.print("Digite o valor da transferencia em R$: ");
                                            double valorTransferencia = scannerDouble();
                                            itemOrigem.transferir(valorTransferencia, itemDestino);
                                            carregandoTela();
                                            limparTela();
                                            System.out.printf("\n\n%.2f foi transferido com sucesso da conta: %d para a conta: %d\n\n",valorTransferencia, itemOrigem.getNumero(), itemDestino.getNumero());
                                            itemOrigem.imprimirExtrato();
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }else if (numTipoOrigem == 2){
                        for (var itemOrigem : Conta.getListaContasPoupanca()) {
                            if(itemOrigem.getNumero() == numContaOrigem){
                                if(numTipoDestino == 1){
                                    for (var itemDestino : Conta.getListaContasCorrente()) {
                                        if(itemDestino.getNumero() == numContaDestino){
                                            System.out.print("Digite o valor da transferencia em R$: ");
                                            double valorTransferencia = scannerDouble();
                                            itemOrigem.transferir(valorTransferencia, itemDestino);
                                            carregandoTela();
                                            limparTela();
                                            System.out.printf("\n\n%.2f foi transferido com sucesso da conta: %d para a conta: %d\n\n",valorTransferencia, itemOrigem.getNumero(), itemDestino.getNumero());
                                            itemOrigem.imprimirExtrato();
                                        }
                                    }
                                }else if(numTipoDestino == 2){
                                    for (var itemDestino : Conta.getListaContasPoupanca()) {
                                        if(itemDestino.getNumero() == numContaDestino){
                                            System.out.print("Digite o valor da transferencia em R$: ");
                                            double valorTransferencia = scannerDouble();
                                            itemOrigem.transferir(valorTransferencia, itemDestino);
                                            carregandoTela();
                                            limparTela();
                                            System.out.printf("\n\n%.2f foi transferido com sucesso da conta: %d para a conta: %d\n\n",valorTransferencia, itemOrigem.getNumero(), itemDestino.getNumero());
                                            itemOrigem.imprimirExtrato();
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    validOpcoesConta = false;
                    break;
                case 5: //Encerrar conta
                    limparTela();
                    System.out.println("Qual o tipo da Conta? \n1 - CORRENTE\n2 - POUPANÇA\n\n");
                    int numTipoEncerrarConta = scannerInt();

                    System.out.print("Digite o número da conta: ");
                    int numContaEncerrarConta = scannerInt();

                    if (numTipoEncerrarConta == 1){
                        for (var item : Conta.getListaContasCorrente()) {
                            if(item.getNumero() == numContaEncerrarConta){
                                if(item.getSaldo() == 0.0d){
                                    System.out.println("\nDeseja mesmo encerrar sua conta corrente? \n1 - S\n2 - N\n\n");
                                    int confirmarExclusao = scannerInt();
                                    if(confirmarExclusao == 1){
                                        boolean x = item.excluirConta(numTipoEncerrarConta, item);
                                        carregandoTela();
                                        limparTela();
                                        if(x){
                                            System.out.printf("Conta %d encerrada com sucesso! \n", item.getNumero());
                                        }else{
                                            System.out.println("Ocorreu um erro, tente novamente!\n");
                                        }
                                    }
                                    break;
                                }
                                else{
                                    System.out.println("Conta contém saldo, deseja sacar antes de encerrar? \n1 - S\n2 - N\n\n");
                                    int erroExcluirConta = scannerInt();
                                    if(erroExcluirConta == 1){
                                        limparTela();
                                        opcoesConta(true);
                                    }else if (erroExcluirConta == 2){
                                        sair();
                                    }
                                }
                            }
                        }
                    }else if (numTipoEncerrarConta == 2){
                        for (var item : Conta.getListaContasPoupanca()) {
                            if(item.getNumero() == numContaEncerrarConta){
                                if(item.getSaldo() == 0.0d){
                                    System.out.println("\nDeseja mesmo encerrar sua conta poupança? \n1 - S\n2 - N\n\n");
                                    int confirmarExclusao = scannerInt();
                                    if(confirmarExclusao == 1){
                                        boolean x = item.excluirConta(numTipoEncerrarConta, item);
                                        carregandoTela();
                                        limparTela();
                                        if(x){
                                            System.out.printf("Conta %d encerrada com sucesso! \n", item.getNumero());
                                        }else{
                                            System.out.println("Ocorreu um erro, tente novamente!\n");
                                        }
                                    }
                                    break;
                                }
                                else{
                                    System.out.println("Conta contém saldo, deseja sacar antes de encerrar? \n1 - S\n2 - N\n\n");
                                    int erroExcluirConta = scannerInt();
                                    if(erroExcluirConta == 1){
                                        limparTela();
                                        opcoesConta(true);
                                    }else if (erroExcluirConta == 2){
                                        sair();
                                    }
                                }
                            }
                        }
                    }
                    validOpcoesConta = false;
                    break;

                case 6:
                    validOpcoesConta = false;
                    sair();
                    break;

                default:
                    limparTela();
                    System.out.print("Valor inválido, digite um valor entre 1 e 6!\n");
                    TimeUnit.SECONDS.sleep(2);
                    validOpcoesConta = true;
                    break;
            }
        }

        System.out.print("\nDeseja fazer outra operação? \n1 - S\n2 - N\n\n");
        int verOutraOperacao = scannerInt();
        if(verOutraOperacao == 1){
            opcoesConta(true);
        }else if (verOutraOperacao == 2){
            sair();
        }

    }

}
