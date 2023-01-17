CREATE TABLE Produto (
	IdentificadorProduto INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nome VARCHAR(255) NOT NULL,
	Valor DECIMAL(15,2) NOT NULL,
	Situacao BIT NOT NULL
);

CREATE TABLE Cliente (
	CpfCliente VARCHAR(11) PRIMARY KEY NOT NULL,
	Nome VARCHAR(255) NOT NULL,
	Nascimento DATE NOT NULL,
	Telefone VARCHAR(15)
);

CREATE TABLE Venda (
	IdentificadorVenda BIGINT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ValorTotal DECIMAL(15,2) NOT NULL,
	ValorDesconto DECIMAL(15,2),
	ValorPago DECIMAL(15,2) NOT NULL,
	DataVenda DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	CpfCliente VARCHAR(11) NOT NULL REFERENCES Cliente(CpfCliente)
);

CREATE TABLE ProdutoVenda (
	IdentificadorProdutoVenda BIGINT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Quantidade INT NOT NULL,
	IdentificadorProduto INT NOT NULL REFERENCES Produto(IdentificadorProduto),
	IdentificadorVenda BIGINT NOT NULL REFERENCES Venda(IdentificadorVenda)
);