using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Sucursal
    {
        public Sucursal()
        {
            id_sucursal = 0;
            nombre = "";
            direccion = "";
            ciudad = "";
            telefonoFijo = "";
            telfonoCelular = "";

        }

        public int id_sucursal { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ@. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Nombre\" es obligatorio.")]
        public string nombre { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ@. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Duirección\" es obligatorio.")]
        public string direccion { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ@. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Ciudad\" es obligatorio.")]
        public string ciudad { get; set; }


        [Range(11111111, 99999999999, ErrorMessage = "El teléfono debe tener 8 dígitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El Teléfono Fijo debe ser numérico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Teléfono Fijo\" es obligatorio.")]
        public string telefonoFijo { get; set; }

        [Range(1111111111, 99999999999, ErrorMessage = "El teléfono debe tener 10 dígitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El Teléfono Celular debe ser numérico")]
        public string telfonoCelular { get; set; }

    }

    
}
