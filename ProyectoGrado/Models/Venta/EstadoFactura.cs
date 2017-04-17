using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class EstadoFactura
    {
        public EstadoFactura()
        {
            id = 0;
            Descripcion = "";
        }
        public EstadoFactura(string descripcion)
        {
            this.Descripcion = descripcion;
        }
        public int id { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
