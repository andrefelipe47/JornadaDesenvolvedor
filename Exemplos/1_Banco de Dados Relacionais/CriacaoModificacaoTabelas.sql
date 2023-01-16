-- aqui estou apagando a tabela produto
DROP TABLE Produto;

-- aqui estou apagando a tabela produto
-- NOT NULL => não permite deixar sem valor
-- PRIMARY KEY => CHAVE PRIMARIA, so pode conter um unico valor desse na tabela
-- IDENTITY (1,1) => Incrementa de 1 em 1 para campo inteiros
-- INT, VARCHAR, DECIMAL, BIT (Representação de int32, string, decimal, bool)
-- Se quiser colocar um valor default, e apensa colocar na frente DEFAULT e o valor compativel na frente
CREATE TABLE Produto (
	IdentificadorProduto INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nome VARCHAR(255) NOT NULL,
	Valor DECIMAL(15,2) NOT NULL,
	Situacao BIT NOT NULL
);

-- Aqui estou adicionando uma nova coluna chamada teste do tipo inteiro
ALTER TABLE Produto ADD Teste INT;
-- Aqui estou alterando o tipo de dados da coluna de int para datetime
ALTER TABLE Produto ALTER COLUMN Teste DATETIME;
-- Aqui estou removendo a coluna teste
ALTER TABLE Produto DROP COLUMN Teste;
