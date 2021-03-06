﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Usuario
    {
        public Usuario()
        {
            idUsuario = 0;
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
            tiposEstado = null;
            NombresApellidosDocumento = "";
            NombresApellidos = "";
        }

        public Usuario(string identif, string apellidos, string nombres)
        {
            this.identificacion = identif;
            this.apellidos = apellidos;
            this.nombres = nombres;
        }
        public Usuario(string apellidos, string nombres)
        {
            this.apellidos = apellidos;
            this.nombres = nombres;
        }



        public int idUsuario { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Nombres\" es obligatorio.")]
        public string nombres { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Apellidos\" es obligatorio.")]
        public string apellidos { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "La identificación debe ser numérica")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Identificación\" es obligatorio.")]
        //[Range(6, 10, ErrorMessage = "La {0} debe estar entre {1} y {2} dígitos.")]
        public string identificacion { get; set; }


        [Range(1111111, 99999999999, ErrorMessage = "El teléfono debe tener 7 dígitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El Teléfono Fijo debe ser numérico")]
        public string TelefonoFijo { get; set; }

        [Range(1111111111, 99999999999, ErrorMessage = "El teléfono celular debe tener 10 digitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El Teléfono celular debe ser numérico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Teléfono Celular\" es obligatorio.")]
        public string TelefonoCelular { get; set; }

        //[RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ#-. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ@. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string direccion { get; set; }


        [StringLength(18, ErrorMessage = "El {0} debe tener un mínimo de 4 caracteres y máximo de 18.", MinimumLength = 4)]
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
        public Sucursal sucursal { get; set; }
        #region Atributos para consulta en vista

        public SelectList sucursalesSelect { get; set; }
        public SelectList tiposIdentificacion { get; set; }
        public SelectList tiposEstado { get; set; }
        public SelectList Roles { get; set; }
        public string NombresApellidosDocumento { get; set; }
        public string NombresApellidos { get; set; }
        #endregion

        public int id { get; set; }
        public string Rol { get; set; }

    }

    
}
