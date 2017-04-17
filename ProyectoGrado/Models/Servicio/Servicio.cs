using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Servicio
    {
        public Servicio()
        {
            id_servicio = 0;
            descripcion = "";
            precio = 0;
        }

        public Servicio(string descripcion)
        {
            this.descripcion = descripcion;
        }
        public Servicio(string descripcion,double precio)
        {
            this.precio = precio;
            this.descripcion = descripcion;
        }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"descripción\" es obligatorio.")]
        public string descripcion { get; set; }
        public int id_servicio { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"precio\" es obligatorio.")]
        public double precio { get; set; }
    }

    
}
