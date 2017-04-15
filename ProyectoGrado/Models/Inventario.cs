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
        }

        public int id_inventario { get; set; }

        public Producto producto { get; set; }

        public int cantidadExistencias { get; set; }

        public DateTime fecha { get; set; }


    }

    
}
