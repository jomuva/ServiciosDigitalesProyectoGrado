using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class TelefonoUsuario
    {
        public TelefonoUsuario()
        {
            ID_TELEFONO = 0;
            ID_USUARIO_TELEFONO = 0;
            NUMERO_TELEFONO = "";
        }
        public int ID_TELEFONO { get; set; }
        public int ID_USUARIO_TELEFONO { get; set; }
        public string NUMERO_TELEFONO { get; set; }
  
    }

    
}
