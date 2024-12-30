function validarDisponibilidad(salaId, fecha) {
    $.ajax({
        url: `/Reservas/ValidarDisponibilidad?salaId=${salaId}&fecha=${fecha}`,
        method: "GET",
        success: function (data) {
            if (data === "1") {
                alert("La sala no está disponible.");
            } else {
                alert("Sala disponible.");
            }
        }
    });
}