var Personalizados = {
    inicializarDatatable: function () {
        $('#table-inicial').dataTable({
            "aaSorting": [[0, "asc"]],
            "oLanguage": { "sUrl": "/App_Settings/Spanish.json" },
            "iDisplayLength": 5,
            "bLengthChange": true,
            "bPaginate": true,
            "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]]
        });
    },


};