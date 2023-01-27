exibirElementosVendedor();
function exibirElementosVendedor() {
    if(nivelAcesso == '1'){
        $("#cardCadastroCliente").show();
    }
}


$(document).ready(function () {
    ListarClientes();
});

var tabelaCliente;
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
    });
}

function ConstruirTabela(linhas) {

    var htmlTabela = '';

    $(linhas).each(function (index, linha) {
        htmlTabela = htmlTabela + `<tr><th>${FormatarCpf(linha.cpfCliente)}</th><td>${linha.nome}</td><td>${FormatarData(linha.nascimento)}</td><td>${FormatarTelefone(linha.telefone)}</td></tr>`;
    });

    $('#tabelaCliente tbody').html(htmlTabela);
    if (tabelaCliente == undefined) {
        tabelaCliente = $('#tabelaCliente').DataTable({
            language: {
                url: 'https://cdn.datatables.net/plug-ins/1.13.1/i18n/pt-BR.json'
            }
        });
    }
}

function ObterValoresFormulario() {
    var cpf = $("#inputCpf").val();
    var nome = $("#inputNome").val();
    var nascimento = $("#inputNascimento").val();
    var telefone = $("#inputTelefone").val();

    var objeto = {
        cpfCliente: LimparMascaraCpf(cpf),
        nome: nome,
        nascimento: nascimento,
        telefone: telefone == "" ? null : LimparMascaraTelefone(telefone)
    };

    return objeto;
}

function EnviarFormularioParaApi() {
    var rotaApi = '/cliente';

    var objeto = ObterValoresFormulario();
    var json = JSON.stringify(objeto);

    $.ajax({
        url: urlBaseApi + rotaApi,
        method: 'POST',
        data: json,
        contentType: 'application/json'
    }).done(function () {
        LimparFormulario();
        ListarClientes();
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Cliente adicionado com sucesso.',
            showConfirmButton: false,
            timer: 1500
        });
    });
}

function LimparFormulario() {
    $('#formCliente').trigger("reset");
}

function SubmeterFormulario() {
    var isValido = $('#formCliente').parsley().validate();
    if (isValido) {
        EnviarFormularioParaApi();
    }
}