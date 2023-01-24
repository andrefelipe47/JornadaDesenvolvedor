var urlBaseApi = "https://localhost:44349";

function LimparCorpoTabelaClientes() {
    var componenteSelecionado = $('#corpoTabelaCliente');
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
        console.log(linha);

        htmlTabela = htmlTabela + `<tr><th>${linha.cpfCliente}</th><td>${linha.nome}</td><td>${linha.nascimento}</td><td>${FormatarTelefone(linha.telefone)}</td></tr>`;
    });

    $('#corpoTabelaCliente').html(htmlTabela);
}

function FormatarTelefone(texto) {
    if (texto == null) {
        return "";
    } else {
        return texto;
    }
}