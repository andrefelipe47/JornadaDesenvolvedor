exibirElementosVendedor();
function exibirElementosVendedor() {
    if (nivelAcesso == '1') {
        $("#cardCadastroCliente").show();
    }
}


$(document).ready(function () {
    ListarClientes();
    $(".preloading").hide();
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

        var botaoAlterar = '<button class="btn btn-primary btn-sm me-2" onclick="Alterar(' + linha.cpfCliente + ')">Alterar</button>';
        var botaoExcluir = '<button class="btn btn-danger btn-sm" onclick="Excluir(' + linha.cpfCliente + ')">Excluir</button>';

        htmlTabela = htmlTabela + `<tr><th>${FormatarCpf(linha.cpfCliente)}</th><td>${linha.nome}</td><td>${FormatarData(linha.nascimento)}</td><td>${FormatarTelefone(linha.telefone)}</td><td>${botaoAlterar + botaoExcluir}</td></tr>`;
    });

    $('#tabelaCliente tbody').html(htmlTabela);
    if (tabelaCliente == undefined) {
        tabelaCliente = $('#tabelaCliente').DataTable({
            language: {
                url: 'dist/datatables/i18n.json'
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

    var isEdicao = $("#inputCpf").is(":disabled");

    if (isEdicao) {
        $.ajax({
            url: urlBaseApi + rotaApi,
            method: 'PUT',
            data: json,
            contentType: 'application/json'
        }).done(function () {
            VoltarEstadoInsercaoFormulario();
            ListarClientes();
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Cliente alterado com sucesso.',
                showConfirmButton: false,
                timer: 1500
            });
        });
    } else {
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

function Excluir(cpfCliente) {
    Swal.fire({
        title: 'Você quer excluir esse cliente?',
        showDenyButton: true,
        confirmButtonText: 'Sim',
        denyButtonText: `Não`,
    }).then((result) => {
        if (result.isConfirmed) {
            EnviarExclusao(cpfCliente);
        } else if (result.isDenied) {
            Swal.fire('Nada foi alterado.', '', 'info')
        }
    });
}

function EnviarExclusao(cpfCliente) {
    var rotaApi = '/cliente/' + cpfCliente;

    $.ajax({
        url: urlBaseApi + rotaApi,
        method: 'DELETE',
    }).done(function () {
        ListarClientes();
        Swal.fire('Cliente excluido com sucesso.', '', 'success');
    });
}

function Alterar(cpfCliente) {
    var rotaApi = '/cliente/' + cpfCliente;

    $.ajax({
        url: urlBaseApi + rotaApi,
        method: 'GET',
        dataType: "json"
    }).done(function (resultado) {
        $("#inputCpf").val(FormatarCpf(resultado.cpfCliente));
        $("#inputNome").val(resultado.nome);
        $("#inputNascimento").val(FormatarDataAmericana(resultado.nascimento));
        $("#inputTelefone").val(FormatarTelefone(resultado.telefone));

        $("#inputCpf").prop("disabled", true);
    });
}

function BotaoCancelar() {
    var isEdicao = $("#inputCpf").is(":disabled");

    if (isEdicao) {
        VoltarEstadoInsercaoFormulario();
    } else {
        LimparFormulario();
    }
}

function VoltarEstadoInsercaoFormulario() {
    LimparFormulario();
    $("#inputCpf").prop("disabled", false);
}

function BaixarRelatorio() {
    fetch('https://localhost:44349/cliente/relatorio')
        .then(resp => resp.blob())
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            // the filename you want
            a.download = 'relatorio.csv';
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        });
}