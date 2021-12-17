import lombok.Getter;

import java.util.ArrayList;

@Getter
public abstract class Conta implements IConta{ //Deixando a classe abstrata para somente as classes filhas poderem instanciar.

    protected Cliente cliente;
    protected int agencia;
    protected int numero;
    protected double saldo;

    protected static ArrayList<ContaCorrente> listaContasCorrente = new ArrayList<>();
    private static ArrayList<ContaPoupanca> listaContasPoupanca = new ArrayList<>();

    private static final int AGENCIA_PADRAO = 1;
    private static int CONTA_SEQUENCIAL = 1;

    public Conta(Cliente cliente){
        this.agencia = AGENCIA_PADRAO;
        this.numero = CONTA_SEQUENCIAL++;
        this.cliente = cliente;
    }

    //Métodos da Interface Conta
    @Override
    public void sacar(double valor) {
        saldo -= valor;
    }

    @Override
    public void depositar(double valor) {
        saldo += valor;
    }

    @Override
    public void transferir(double valor, IConta contaDestino) {
            this.sacar(valor);
            contaDestino.depositar(valor);
    }

    @Override
    public boolean excluirConta(int tipoConta, IConta contaEncerrar) {

        if(tipoConta == 1){
            for (var itemEx1 : Conta.getListaContasCorrente()) {
                if(itemEx1 == contaEncerrar){
                   return listaContasCorrente.remove(itemEx1);
                }
            }
        }
        else if (tipoConta == 2){
            for (var itemEx2 : Conta.getListaContasPoupanca()) {
                if(itemEx2 == contaEncerrar){
                    return listaContasCorrente.remove(itemEx2);
                }
            }
        }
        return false;
    }

    protected void ImprimirInfosComuns() {
        System.out.println(String.format("Titular: %s", this.cliente.getNome()));
        System.out.println(String.format("Agencia: %d", this.agencia));
        System.out.println(String.format("Numero: %d", this.numero));
        System.out.println(String.format("Saldo: %.2f", this.saldo));
    }

    //Gets & Sets
    public String getCliente() {
        return cliente.getNome();
    }

    public static ArrayList<ContaPoupanca> getListaContasPoupanca() {
        return listaContasPoupanca;
    }
    public static void setListaContasPoupanca(ArrayList<ContaPoupanca> listaContasPoupanca) {
        Conta.listaContasPoupanca = listaContasPoupanca;
    }

    public static ArrayList<ContaCorrente> getListaContasCorrente() {
        return listaContasCorrente;
    }
    public static void setListaContasCorrente(ArrayList<ContaCorrente> listaContasCorrente) {
        Conta.listaContasCorrente = listaContasCorrente;
    }
}
