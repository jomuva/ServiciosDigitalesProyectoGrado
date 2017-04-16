$("#btnElemento").click(function(eve){
    $("#modal-content").load("/Solicitudes/ConsultarElementosModal");
});

$("#btnAnotacion").click(function (eve) {
    $("#modal-content").load("/Solicitudes/AgregarAnotacionModal/" + $(this).data("id"));
});

$("#btnAnotacionInventario").click(function (eve) {
    debugger;
    $("#modal-content").load("/Inventarios/AgregarAnotacionInventario/" + $(this).data("id"));
});


$("#btnAnotacionInventarioBajas").click(function (eve) {
    debugger;
    $("#modal-content").load("/Inventarios/AgregarAnotacionInventarioBajas/" + $(this).data("id"));
});



