programa
{
	
	funcao inicio()
	{
		escreva("Calculadora de quanto seu veículo consegue percorrer\n\n")

		real litrosAbastecido
		escreva("Quantos litros você colocou no seu tanque? ")
		leia(litrosAbastecido)

		real consumoVeiculo
		escreva("\nQual o consumo do seu veículo? ")
		leia(consumoVeiculo)

		real distanciaMaxima = consumoVeiculo * litrosAbastecido
		escreva("\nO seu veículo consegue percorrer " + distanciaMaxima + "km")
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 342; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */