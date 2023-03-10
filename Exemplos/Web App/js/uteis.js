$(document).ready(function () {
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.telefone').mask('(00) 00000-0000');

    $.ajaxSetup({
        headers: { 'Authorization': 'Bearer ' + localStorage.getItem('bearer')},
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status == 400) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: jqXHR.responseText
                });
            } else if (jqXHR.status == 0) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Os nossos servidores ou sua internet estão indisponíveis no momento, tente novamente mais tarde.'
                });
            }
            else if (jqXHR.status == 401) {
                Swal.fire({
                    icon: 'info',
                    title: 'Oops...',
                    text: 'As suas credenciais expiraram, faça login novamente.'
                }).then((result) => {
                    window.location.href = "index.html";
                });
            }
            else if (jqXHR.status == 403) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Acesso Negado',
                    text: 'Você não tem permissão para acessar este recurso.'
                });
            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: jqXHR.responseText
                });
            }
        }
    });
});

function FormatarTelefone(texto) {
    if (texto == null) {
        return "";
    } else {

        var ddd = texto.slice(0, 2);
        var primeiroNumero = texto.slice(2, 7);
        var segundoNumero = texto.slice(7, 11);

        return `(${ddd}) ${primeiroNumero}-${segundoNumero}`;
    }
}

function FormatarData(dataString) {
    var dataTeste = new Date(dataString);
    var ano = dataTeste.getFullYear();
    var mes = String(dataTeste.getMonth() + 1).length == 1 ? '0' + String(dataTeste.getMonth() + 1) : String(dataTeste.getMonth() + 1);
    var dia = String(dataTeste.getDate()).length == 1 ? '0' + String(dataTeste.getDate()) : String(dataTeste.getDate());

    return dia + "/" + mes + "/" + ano;
}

function FormatarDataAmericana(dataString) {
    var dataTeste = new Date(dataString);
    var ano = dataTeste.getFullYear();
    var mes = String(dataTeste.getMonth() + 1).length == 1 ? '0' + String(dataTeste.getMonth() + 1) : String(dataTeste.getMonth() + 1);
    var dia = String(dataTeste.getDate()).length == 1 ? '0' + String(dataTeste.getDate()) : String(dataTeste.getDate());

    return ano + "-" + mes + "-" + dia;
}

function FormatarCpf(cpfString) {
    var p1 = cpfString.slice(0, 3);
    var p2 = cpfString.slice(3, 6);
    var p3 = cpfString.slice(6, 9);
    var digitoVerificador = cpfString.slice(9, 11);

    return `${p1}.${p2}.${p3}-${digitoVerificador}`;
}

function LimparMascaraCpf(cpfString) {
    return cpfString.replace(/\./g, "").replace(/\-/g, "");
}

function LimparMascaraTelefone(telefoneString) {
    return telefoneString.replace(/\(/g, "").replace(/\)/g, "").replace(/\ /g, "").replace(/\-/g, "");
}

var nivelAcesso = localStorage.getItem('nivelAcesso');