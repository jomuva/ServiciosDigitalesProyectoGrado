using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class DetalleFacturaSolicitud
    {
        public DetalleFacturaSolicitud()
        {
            id = 0;
            solicitud = new Solicitud();
            cantidad = 0;
        }
       

        public int id { get; set; }
        public Solicitud solicitud { get; set; }
        public int cantidad { get; set; }

    }

    
}
