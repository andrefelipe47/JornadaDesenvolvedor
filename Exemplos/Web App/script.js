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

    $(linhas).each(function (index, linha) {
        console.log(linha);
    });

}