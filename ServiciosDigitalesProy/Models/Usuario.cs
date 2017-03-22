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
            sexo = "";
            estado = "";
            username = "";
            tiposIdentificacion = null ;
        }

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public string direccion { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public string estado { get; set; }
        public string username { get; set; }
        public int idRol { get; set; }
        public int idEstado { get; set; }
        public int idTipoIdentificacion { get; set; }
        public SelectList tiposIdentificacion { get; set; }

    }

    
}
