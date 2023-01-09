programa
{
	inclua biblioteca Tipos
	
	funcao inicio()
	{
		escreva("Calculadora de quanto seu veículo consegue percorrer\n\n")

		cadeia litrosAbastecidoString
		escreva("Quantos litros você colocou no seu tanque? ")
		leia(litrosAbastecidoString)

		se(ValidarFormatarValores(litrosAbastecidoString) < 0)
		{
			retorne
		}

		real litrosAbastecido = ValidarFormatarValores(litrosAbastecidoString)

		cadeia consumoVeiculoString
		escreva("\nQual o consumo do seu veículo? ")
		leia(consumoVeiculoString)

		se(ValidarFormatarValores(consumoVeiculoString) < 0)
		{
			retorne
		}

		real consumoVeiculo = ValidarFormatarValores(consumoVeiculoString)

		real distanciaMaxima = consumoVeiculo * litrosAbastecido
		escreva("\nO seu veículo consegue percorrer " + distanciaMaxima + "km")
	}

	funcao real ValidarFormatarValores(cadeia valorEmTexto)
	{
		logico isReal = Tipos.cadeia_e_real(valorEmTexto)
		logico isNumero = Tipos.cadeia_e_inteiro(valorEmTexto, 10)
		se(isReal == falso e isNumero == falso){
			escreva("\nInsira um número válido, e execute o programa novamente.")
			retorne -1.00
		}

		real resultadoFormatado = Tipos.cadeia_para_real(valorEmTexto)

		se(resultadoFormatado <= 0){
			escreva("\nInsira um número positivo, e execute o programa novamente.")
			retorne -1.00
		}
		
		retorne resultadoFormatado
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 1197; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */