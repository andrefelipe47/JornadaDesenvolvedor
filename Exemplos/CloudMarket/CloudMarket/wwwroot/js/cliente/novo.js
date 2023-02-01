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
    $(".preloading").show();

    var rotaApi = '/cliente';

    var objeto = ObterValoresFormulario();
    var json = JSON.stringify(objeto);

    $.ajax({
        url: rotaApi,
        method: 'POST',
        data: json,
        contentType: 'application/json'
    }).done(function () {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Cliente adicionado com sucesso.',
            showConfirmButton: false,
            timer: 1500
        });

        setTimeout(function () {
            RedirecionarListagem();
        }, 1500);
    });
}



function SubmeterFormulario() {
    var isValido = $('#formCliente').parsley().validate();
    if (isValido) {
        EnviarFormularioParaApi();
    }
}


function RedirecionarListagem() {
    window.location.href = "/cliente";
}