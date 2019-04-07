
// Envia peticion Ajax al servidor
function send() {
    var sigla = $("#sigla").val();
    $.ajax({
        url: "/ApiConsume/GetApi?sigla=" + sigla,

        success: function (resultado) {
            if (resultado == "Error") {
                alert("Error, se ha ingresado una sigla no valida. Por favor intenten de nuevo.");
                return;
            }
            setValores(resultado.Data)
        }
    });

}
// Limpia campos del formulario
function clear() {
    $("#name").val(" ");
    $("#region").val(" ");
    $("#capital").val(" ");
}

// Setea valores a los campos del formulario
function setValores(valor) {
    $("#name").val(valor.name);
    $("#region").val(valor.region);
    $("#capital").val(valor.capital);
}

