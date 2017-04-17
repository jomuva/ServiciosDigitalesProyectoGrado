using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class EstadosUsuario
    {
        public EstadosUsuario()
        {
            id = 0;
            Descripcion = "";
        }
        public int id { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
