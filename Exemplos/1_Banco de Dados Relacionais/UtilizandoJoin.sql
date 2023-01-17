SELECT v.* FROM Cliente c
JOIN Venda v ON v.CpfCliente = c.CpfCliente
WHERE c.CpfCliente = '00000000000';

SELECT pv.Quantidade, p.Nome, p.Valor FROM Cliente c
JOIN Venda v ON v.CpfCliente = c.CpfCliente
JOIN ProdutoVenda pv ON pv.IdentificadorVenda = v.IdentificadorVenda
JOIN Produto p ON p.IdentificadorProduto = pv.IdentificadorProduto
WHERE c.CpfCliente = '00000000000';

SELECT pv.Quantidade, p.Nome, p.Valor FROM Cliente c
JOIN Venda v ON v.CpfCliente = c.CpfCliente
JOIN ProdutoVenda pv ON pv.IdentificadorVenda = v.IdentificadorVenda
JOIN Produto p ON p.IdentificadorProduto = pv.IdentificadorProduto
WHERE c.CpfCliente = '00000000000'
AND v.IdentificadorVenda = 1;