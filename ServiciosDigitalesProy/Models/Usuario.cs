using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class Usuario
    {
        public Usuario()
        {
            nombres = "";
            apellidos = "";
            tipo_identificacion = new TipoIdentificacion();
            identificacion = "";
            telefonos = new List<TelefonoUsuario>();
            direccion = "";
            password = "";
            email = "";
            sexo = "";
            estado = "";
            username = "";
        }

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public TipoIdentificacion tipo_identificacion { get; set; }
        public string identificacion { get; set; }
        public List<TelefonoUsuario> telefonos { get; set; }
        public string direccion { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public string estado { get; set; }
        public string username { get; set; }
        public int idRol { get; set; }
        public int idEstado { get; set; }
        public int idTipoIdentificacion { get; set; }

    }

    
}
