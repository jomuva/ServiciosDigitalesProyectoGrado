$("#btnElemento").click(function(eve){
    $("#modal-content").load("/Solicitudes/ConsultarElementosModal");
});

$("#btnAnotacion").click(function (eve) {
    $("#modal-content").load("/Solicitudes/AgregarAnotacionModal/" + $(this).data("id"));
});


