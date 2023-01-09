programa
{
	
	funcao inicio()
	{
		escreva("Calculadora de consumo\n\n")

		real quantidadeCombustivel
		escreva("Quantos litros tinha no seu tanque: ")
		leia(quantidadeCombustivel)

		real distanciaPercorrida
		escreva("\nQuantos KM você percorreu com o tanque: ")
		leia(distanciaPercorrida)

		real consumo = distanciaPercorrida / quantidadeCombustivel
		escreva("\nSeu carro realiza: " + consumo + "km por litro.")
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 301; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */