using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class TelefonoUsuario
    {
        public TelefonoUsuario()
        {
            id_usuario_telefono = 0;
            numero_telefono = "";
        }

        public int id_usuario_telefono { get; set; }
        public string numero_telefono { get; set; }

    }
}
