$("#btnElemento").click(function(eve){
    $("#modal-content").load("/Solicitudes/ConsultarElementosModal");
});

$("#btnAnotacion").click(function (eve) {
    $("#modal-content").load("/Solicitudes/AgregarAnotacionModal/" + $(this).data("id"));
});

$("#btnAnotacion1").click(function (eve) {
    $("#modal-content").load("/Inventarios/AgregarAnotacionInventario/" + $(this).data("id"));
});

//Modales Crear Factura 
$("#btnBuscarCliente").click(function (eve) {
    $("#modal-content1").load("/Ventas/BuscarClientes");
});

$("#btnAdicionarProducto").click(function (eve) {
    $("#modal-content2").load("/Ventas/BuscarProducto");
});

$("#btnAdicionarSolicitud").click(function (eve) {
    $("#modal-content3").load("/Ventas/BuscarSolicitudes");
});

//$("#btnAnular").click(function (eve) {
//    $("#modal-content4").load("/Ventas/AnularFactura/"+ $(this).data("id"));
//});






