INSERT INTO Produto (Nome, Valor, Situacao) VALUES ('creme de leite tradicional itamb� 200g',3.49,1);
INSERT INTO Produto (Nome, Valor, Situacao) VALUES ('refil para repelente el�trico pastilha sbp com 12 unidades citronela',2.99,1);
INSERT INTO Produto (Nome, Valor, Situacao) VALUES ('papel higi�nico neve folha dupla toque seda - leve 12 pague 11',17.99,1);
INSERT INTO Produto (Nome, Valor, Situacao) VALUES ('caf� em p� 3 cora��es tradicional 500g',16.49,1);
INSERT INTO Produto (Nome, Valor, Situacao) VALUES ('hamb�rguer angus super nosso tradicional congelado 360g com 2 unidades',12.90,1);
INSERT INTO Produto (Nome, Valor, Situacao) VALUES ('Picanha Montana 1,5Kg',134.85,1);

INSERT INTO Cliente (CpfCliente, Nome, Nascimento) VALUES ('00000000000', 'ANDRE MARTINS', '1900-01-01');
INSERT INTO Cliente (CpfCliente, Nome, Nascimento) VALUES ('11111111111', 'GABRIEL MARTINS', '1900-01-01');

INSERT INTO Venda (ValorTotal, ValorDesconto, ValorPago, DataVenda, CpfCliente) VALUES (23.47, NULL, 23.47, CURRENT_TIMESTAMP, '00000000000');

INSERT INTO ProdutoVenda (Quantidade, IdentificadorProduto, IdentificadorVenda) VALUES (2,1,1);
INSERT INTO ProdutoVenda (Quantidade, IdentificadorProduto, IdentificadorVenda) VALUES (1,4,1);

INSERT INTO Venda (ValorTotal, ValorDesconto, ValorPago, DataVenda, CpfCliente) VALUES (23.47, NULL, 23.47, CURRENT_TIMESTAMP, '00000000000');

INSERT INTO ProdutoVenda (Quantidade, IdentificadorProduto, IdentificadorVenda) VALUES (2,1,2);
INSERT INTO ProdutoVenda (Quantidade, IdentificadorProduto, IdentificadorVenda) VALUES (1,4,2);