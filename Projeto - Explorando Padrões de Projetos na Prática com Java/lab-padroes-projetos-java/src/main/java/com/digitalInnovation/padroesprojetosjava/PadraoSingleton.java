package com.digitalInnovation.padroesprojetosjava;

public final class PadraoSingleton {

    private static PadraoSingleton instance;
    public String value;

    private PadraoSingleton(String value) {

        try {
            Thread.sleep(1000);
        } catch (InterruptedException ex) {
            ex.printStackTrace();
        }
        this.value = value;
    }

    public static PadraoSingleton getInstance(String value) {
        if (instance == null) {
            instance = new PadraoSingleton(value);
        }
        return instance;
    }
}