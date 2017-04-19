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


        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,500}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string Descripcion { get; set; }
  
    }

    
}
