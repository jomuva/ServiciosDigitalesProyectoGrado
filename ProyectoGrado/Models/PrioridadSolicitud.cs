using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class PrioridadSolicitud
    {
        public PrioridadSolicitud()
        {
            id = 0;
            Descripcion = "";
            tiempoSolucion = 0;
        }

        public PrioridadSolicitud(string descripcion)
        {
            this.Descripcion = descripcion;
        }
        public int id { get; set; }
        public string Descripcion { get; set; }

        public int tiempoSolucion { get; set; }

    }

    
}
