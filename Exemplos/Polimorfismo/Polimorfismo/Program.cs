using Polimorfismo.Models;

var poupanca = new Poupanca();
poupanca.Saldo = 5000;
poupanca.Rentabilidade = 13.5M;
var saldoFuturo = poupanca.CalcularSaldoFuturo(12);

var cdb = new Cdb();
cdb.Saldo = 5000;
cdb.Rentabilidade = 13.5M;
saldoFuturo = cdb.CalcularSaldoFuturo(12);