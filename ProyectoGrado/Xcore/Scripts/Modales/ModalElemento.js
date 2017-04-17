$("#btnElemento").click(function(eve){
    $("#modal-content").load("/Solicitudes/ConsultarElementosModal");
});

$("#btnAnotacion").click(function (eve) {
    $("#modal-content").load("/Solicitudes/AgregarAnotacionModal/" + $(this).data("id"));
});

//Modales Crear Factura 
$("#btnBuscarCliente").click(function (eve) {
    $("#modal-content1").load("/Ventas/BuscarClientes");
});

$("#btnAdicionarProducto").click(function (eve) {
    $("#modal-content2").load("/Ventas/BuscarProducto");
});



