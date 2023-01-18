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


select 
	SUM(pv.Quantidade) AS QuantidadeVendidas,
	p.IdentificadorProduto,
	p.Nome
FROM ProdutoVenda pv
JOIN Produto p ON p.IdentificadorProduto = pv.IdentificadorProduto
GROUP BY p.IdentificadorProduto, p.Nome



-- Total da venda usando as funcoes agrupadoras
SELECT SUM(p.Valor * pv.Quantidade), v.IdentificadorVenda, v.CpfCliente, c.Nome FROM Venda v

JOIN ProdutoVenda pv ON pv.IdentificadorVenda = v.IdentificadorVenda
JOIN Produto p ON p.IdentificadorProduto = pv.IdentificadorProduto
JOIN Cliente c ON c.CpfCliente = v.CpfCliente

WHERE v.IdentificadorVenda = 3
GROUP BY v.IdentificadorVenda, v.CpfCliente, c.Nome

-- Mesmo resultado sem agrupar
SELECT (p.Valor * pv.Quantidade), v.IdentificadorVenda, v.CpfCliente, c.Nome FROM Venda v

JOIN ProdutoVenda pv ON pv.IdentificadorVenda = v.IdentificadorVenda
JOIN Produto p ON p.IdentificadorProduto = pv.IdentificadorProduto
JOIN Cliente c ON c.CpfCliente = v.CpfCliente

WHERE v.IdentificadorVenda = 3