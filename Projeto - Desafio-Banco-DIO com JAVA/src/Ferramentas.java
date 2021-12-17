import java.util.Scanner;
import java.util.concurrent.TimeUnit;

public class Ferramentas {

    //Método para "Limpar" a tela
    public static void limparTela(){
        for (int i = 0; i < 50; ++i) { System.out.println (); }
    }

    //Carregamento de tela
    public static void carregandoTela() throws InterruptedException {
        System.out.print("Carregando.");
        TimeUnit.MILLISECONDS.sleep(500);
        System.out.print(".");
        TimeUnit.MILLISECONDS.sleep(500);
        System.out.print(".");
        TimeUnit.MILLISECONDS.sleep(500);
    }

    //Método retorna int com o valor inserido
    public static int scannerInt(){
        Scanner scan = new Scanner(System.in);
        return scan.nextInt();
    }

    //Método retorna String com o valor inserido
    public static String scannerString(){
        Scanner scan = new Scanner(System.in);
        return scan.nextLine();
    }

    //Método retorna double com o valor inserido
    public static double scannerDouble(){
        Scanner scan = new Scanner(System.in);
        return scan.nextDouble();
    }

    //Método para sair do programa
    public static void sair(){
        System.out.print("\n\nObrigado por utilizar o banco, até logo!!! :D");
        System.exit(0);
    }
}
