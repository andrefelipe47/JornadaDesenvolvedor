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

function FormatarCpf(cpfString) {
    var p1 = cpfString.slice(0, 3);
    var p2 = cpfString.slice(3, 6);
    var p3 = cpfString.slice(6, 9);
    var digitoVerificador = cpfString.slice(9, 11);

    return `${p1}.${p2}.${p3}-${digitoVerificador}`;
}