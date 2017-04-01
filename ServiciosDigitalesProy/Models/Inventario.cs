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
            id_producto = 0;
            cantidadExistencias = 0;
        }

        public int id_producto { get; set; }

        public int cantidadExistencias { get; set; }

        public DateTime fecha { get; set; }


    }

    
}
