$(document).ready(function() {
    ListarClientes();
});

var urlBaseApi = "https://localhost:44349";


function LimparCorpoTabelaClientes() {
    var componenteSelecionado = $('#tabelaCliente tbody');
    componenteSelecionado.html('');
}

function ListarClientes() {
    var rotaApi = '/cliente';

    $.ajax({
        url: urlBaseApi + rotaApi,
        method: 'GET',
        dataType: "json"
    }).done(function (resultado) {
        ConstruirTabela(resultado);
    }).fail(function (err, errr, errrr) {

    });
}

function ConstruirTabela(linhas) {

    var htmlTabela = '';

    $(linhas).each(function (index, linha) {
        htmlTabela = htmlTabela + `<tr><th>${linha.cpfCliente}</th><td>${linha.nome}</td><td>${FormatarData(linha.nascimento)}</td><td>${FormatarTelefone(linha.telefone)}</td></tr>`;
    });

    $('#tabelaCliente tbody').html(htmlTabela);
    $('#tabelaCliente').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.13.1/i18n/pt-BR.json'
        }
    });
}

function FormatarTelefone(texto) {
    if (texto == null) {
        return "";
    } else {

        var ddd = texto.slice(0,2);
        var primeiroNumero = texto.slice(2,7);
        var segundoNumero = texto.slice(7,11);

        return `(${ddd}) ${primeiroNumero}-${segundoNumero}`;
    }
}

function FormatarData(dataString){
    var dataTeste = new Date(dataString);
    var ano = dataTeste.getFullYear();
    var mes = String(dataTeste.getMonth() + 1).length == 1 ? '0' + String(dataTeste.getMonth() + 1) : String(dataTeste.getMonth() + 1);
    var dia = String(dataTeste.getDate()).length == 1 ? '0' + String(dataTeste.getDate()) : String(dataTeste.getDate());

    return dia + "/" + mes + "/" + ano;
}