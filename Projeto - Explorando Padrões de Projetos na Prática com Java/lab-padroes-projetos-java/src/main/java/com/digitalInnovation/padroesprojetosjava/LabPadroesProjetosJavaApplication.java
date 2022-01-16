package com.digitalInnovation.padroesprojetosjava;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class LabPadroesProjetosJavaApplication {

	/**
	 * Padrão Singleton: O Singleton pode ser reconhecido por um método de criação estático, que retorna o mesmo objeto em cache.
	 * Projeto Spring Boot gerado via Spring Initializr.
	 * Os seguintes módulos foram selecionados:
	 * - Spring Data JPA
	 * - Spring Web
	 * - H2 Database
	 * - OpenFeign
	 *
	 * @author lucasmarcuzo
	 */

	public static void main(String[] args) {
		SpringApplication.run(LabPadroesProjetosJavaApplication.class, args);

		System.out.println("\nSe você ver o mesmo valor, o singleton foi reutilizado!" + "\n" +
		"Se você ver valores diferentes, então 2 singletons foram criados!" + "\n\n");

		PadraoSingleton singleton = PadraoSingleton.getInstance("FOO");
		PadraoSingleton anotherSingleton = PadraoSingleton.getInstance("BAR");

		System.out.print("Resultado: \n");
		System.out.println(singleton.value);
		System.out.println(anotherSingleton.value);

	}

}
