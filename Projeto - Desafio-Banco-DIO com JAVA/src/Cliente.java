import lombok.Data;
import lombok.Getter;

import java.util.ArrayList;

@Getter
public class Cliente{

    private String nome;
    private static ArrayList<Cliente> listaClientes = new ArrayList<Cliente>();

    public Cliente(String nome){
        this.nome = nome;
    }

    //gets e sets
    public static ArrayList<Cliente> getListaClientes() {
        return listaClientes;
    }

    public static void setListaClientes(ArrayList<Cliente> listaClientes) {
        Cliente.listaClientes = listaClientes;
    }
}
