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

CREATE TABLE Cargo (
	IdentificadorCargo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(20) NOT NULL
);

INSERT INTO Cargo (Descricao) VALUES ('Vendedor');
INSERT INTO Cargo (Descricao) VALUES ('Marketing');

CREATE TABLE Usuario (
	Email varchar(255) NOT NULL PRIMARY KEY,
	Senha varchar(128) NOT NULL,
	Nome VARCHAR(80)  NOT NULL,
	IdentificadorCargo INT NOT NULL REFERENCES Cargo(IdentificadorCargo)
);

INSERT INTO Usuario (Email, Senha, Nome, IdentificadorCargo) 
VALUES ('vendedor@rumosolucoes.com', 
'ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413',
'Vendedor da Silva',
1);

INSERT INTO Usuario (Email, Senha, Nome, IdentificadorCargo) 
VALUES ('marketing@rumosolucoes.com', 
'ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413',
'Marketeiro da Rumo',
2);