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
        }

        public Servicio(string descripcion)
        {
            this.descripcion = descripcion;
        }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"descripción\" es obligatorio.")]
        public string descripcion { get; set; }
        public int id_servicio { get; set; }

    }

    
}
