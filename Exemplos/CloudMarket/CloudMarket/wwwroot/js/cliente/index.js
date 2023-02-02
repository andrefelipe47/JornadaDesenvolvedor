$(document).ready(function () {
    ListarClientes();
});

var tabelaCliente;

function ListarClientes() {
    var rotaApi = '/cliente/listar';

    $.ajax({
        url: rotaApi,
        method: 'GET',
        dataType: "json"
    }).done(function (resultado) {
        ConstruirTabela(resultado);
    });
}

function ConstruirTabela(linhas) {

    var htmlTabela = '';

    $(linhas).each(function (index, linha) {

        var botaoAlterar = '<button class="btn btn-primary btn-sm botaoAlterarListagem" onclick="Alterar(' + linha.cpfCliente + ')"><i class="fa-solid fa-pen"></i></button>';
        var botaoExcluir = '<button class="btn btn-danger btn-sm" onclick="Excluir(' + linha.cpfCliente + ')"><i class="fa-solid fa-trash"></i></button>';

        htmlTabela = htmlTabela + `<tr><th>${FormatarCpf(linha.cpfCliente)}</th><td>${linha.nome}</td><td>${FormatarData(linha.nascimento)}</td><td>${FormatarTelefone(linha.telefone)}</td><td>${botaoAlterar + botaoExcluir}</td></tr>`;
    });

    $('#tabelaCliente tbody').html(htmlTabela);
    if (tabelaCliente == undefined) {
        tabelaCliente = $('#tabelaCliente').DataTable({
            language: {
                url: 'i18n/datatables.json'
            }
        });
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
        url: rotaApi,
        method: 'DELETE',
    }).done(function () {
        ListarClientes();
        Swal.fire('Cliente excluido com sucesso.', '', 'success');
    });
}

function BaixarRelatorio() {
    fetch('/cliente/relatorio')
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

function RedirecionarNovoCliente() {
    window.location.href = "/cliente/novo";
}