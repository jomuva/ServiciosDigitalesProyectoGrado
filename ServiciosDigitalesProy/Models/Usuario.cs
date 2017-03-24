using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Usuario
    {
        public Usuario()
        {
            nombres = "";
            apellidos = "";
            identificacion = "";
            direccion = "";
            TelefonoCelular = "";
            TelefonoFijo = "";
            password = "";
            email = "";
            estado = "";
            username = "";
            tiposIdentificacion = null ;
        }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Nombres\" es obligatorio.")]
        public string nombres { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Apellidos\" es obligatorio.")]
        public string apellidos { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "El Teléfono celular debe ser numérico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Identificación\" es obligatorio.")]
        public string identificacion { get; set; }

        public string TelefonoFijo { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "El Teléfono celular debe ser numérico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Teléfono Celular\" es obligatorio.")]
        public string TelefonoCelular { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ#. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string direccion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Password\" es obligatorio.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Verificación Password\" es obligatorio.")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "Las Contraseñas no coinciden.")]
        public string verificacionPassword { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ@. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Email\" es obligatorio.")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Sexo\" es obligatorio.")]
        public string sexo { get; set; }
        public string estado { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ@. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Username\" es obligatorio.")]
        public string username { get; set; }
        public int idRol { get; set; }
        public int idEstado { get; set; }
        public int idTipoIdentificacion { get; set; }
        public SelectList tiposIdentificacion { get; set; }

    }

    
}
