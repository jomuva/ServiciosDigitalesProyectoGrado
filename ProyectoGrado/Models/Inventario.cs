using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Inventario
    {
        public Inventario()
        {
            id_inventario = 0;
            cantidadExistencias = 0;
            producto = new Producto();
            historico = new HistoricoInventario();
            fecha = new DateTime();
        }

        public int id_inventario { get; set; }

        public Producto producto { get; set; }

        [Range(1, 1000, ErrorMessage = "Debe agregar una cantidad entre 1 y 1000 unidades")]
        public int cantidadExistencias { get; set; }

        public DateTime fecha { get; set; }

        public HistoricoInventario historico { get; set; }


    }

    
}
