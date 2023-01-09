programa
{
	inclua biblioteca Tipos
	
	funcao inicio()
	{
		escreva("Calculadora de consumo\n\n")

		cadeia quantidadeCombustivelString
		escreva("Quantos litros tinha no seu tanque: ")
		leia(quantidadeCombustivelString)
		se(ValidarFormatarValores(quantidadeCombustivelString) < 0)
		{
			retorne
		}

		real quantidadeCombustivel = ValidarFormatarValores(quantidadeCombustivelString)

		cadeia distanciaPercorridaString
		escreva("\nQuantos KM você percorreu com o tanque: ")
		leia(distanciaPercorridaString)

		se(ValidarFormatarValores(distanciaPercorridaString) < 0)
		{
			retorne
		}

		real distanciaPercorrida = ValidarFormatarValores(distanciaPercorridaString)

		real consumo = distanciaPercorrida / quantidadeCombustivel
		escreva("\nSeu carro realiza: " + consumo + "km por litro.")
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
			escreva("\nInsira um número maior que zero, e execute o programa novamente.")
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
 * @POSICAO-CURSOR = 1255; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = {isNumero, 37, 9, 8};
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */