using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class HistoricoFactura
    {
        public HistoricoFactura()
        {
            id_Historico = 0;
            empleado = new Usuario();
            id_Factura = 0;
            fecha = new DateTime();
            descripcion = "";
        }

        public int id_Historico { get; set; }
        public Usuario empleado { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public int id_Factura { get; set; }

    }


}
