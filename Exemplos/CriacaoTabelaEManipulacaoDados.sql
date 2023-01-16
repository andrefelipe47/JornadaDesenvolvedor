CREATE TABLE Produto (
	IdentificadorProduto INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nome VARCHAR(255) NOT NULL,
	Valor DECIMAL(15,2) NOT NULL,
	Situacao BIT NOT NULL
);
--Insere uma linha nova na tabela produto
INSERT INTO Produto (Nome, Valor, Situacao)
VALUES ('Feijão', 20.99, 1);

--Insere uma linha nova na tabela produto
INSERT INTO Produto (Nome, Valor, Situacao)
VALUES ('Arroz', 20.99, 1);

--Seleciona (*) todas as colunas e exibi para a consulta realizada em toda a tabela Produto
SELECT * FROM Produto;

--Atualiza o valor na tabela Produto caso o Identificador seja igual a 2
UPDATE Produto SET Valor = 21.99 WHERE IdentificadorProduto = 2;

--Pesquisa pela coluna Nome na tabela Produto
SELECT * FROM Produto WHERE Nome = 'Arroz';

--Esta pesquisa não vai retorar nada, pois o Identificador do Produto do arroz e igual a 2
SELECT * FROM Produto WHERE Nome = 'Arroz' AND IdentificadorProduto = 1;

--Quero deletar o feijao da tabela Produto
DELETE Produto WHERE IdentificadorProduto = 1;

--Quero saber apenas os nomes dos produtos que existem dentro da minha tabela Produtos
SELECT Nome FROM Produto;

--Vou inserir vários produtos
INSERT INTO Produto (Nome, Valor, Situacao)
VALUES ('Sorvete', 13.99, 1);
INSERT INTO Produto (Nome, Valor, Situacao)
VALUES ('Bombom', 9.99, 1);
INSERT INTO Produto (Nome, Valor, Situacao)
VALUES ('Biscoito', 1.49, 1);

--Quero saber quantos tipos de produtos vendemos no supermercado
SELECT COUNT(IdentificadorProduto) FROM Produto;

--Quero saber quantos tipos de produtos vendemos que estao ativos no supermercado
SELECT COUNT(IdentificadorProduto) FROM Produto WHERE Situacao = 1;

--Renomei a saida de uma coluna
SELECT COUNT(IdentificadorProduto) AS TotalProdutos FROM Produto WHERE Situacao = 1;

-- Retornei na saida, duas colunas, sendo a contagem de produtos
-- e também a media do preco e soma
-- para os produtos que estão com a situacao igual a 1 ou seja true
SELECT 
	COUNT(IdentificadorProduto) AS TotalProdutos,
	AVG(Valor) AS MediaPreco,
	SUM(Valor) AS SomaPreco
FROM Produto 
WHERE Situacao = 1;