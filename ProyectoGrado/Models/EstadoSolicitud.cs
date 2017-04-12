using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class EstadoSolicitud
    {
        public EstadoSolicitud()
        {
            id = 0;
            Descripcion = "";
        }
        public EstadoSolicitud(string descripcion)
        {
            this.Descripcion = descripcion;
        }
        public int id { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
