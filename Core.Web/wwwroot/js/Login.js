$(function () {
    $('#form-usuario-generico').on('submit', function (event) {
        event.preventDefault();
        event.preventDefault();
        var model = {
            email: $('#Identificacion').val(),
            contrasenia: $("#Llave").val()
        }

        debugger;

        $.ajax({
            type: "POST",
            url: `/ingreso-usuario`,
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8"
        }).done(function (data) {

            location.href = "/wf/v1/mis-solicitudes"

        }).fail(function (errMsg) {
            $.niftyNoty({
                type: "warning",
                container: "floating",
                title: "Problemas",
                message: "Revisa los Logs<br/><small>Este mensaje se cierra en 5 segundos.</small>",
                closeBtn: true,
                timer: 5000
            });
        });
    });
});