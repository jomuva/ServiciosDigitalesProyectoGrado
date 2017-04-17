using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class HistoricoInventario
    {
        public HistoricoInventario()
        {
            id_Historico = 0;
            empleado = new Usuario();
            id_inventario = 0;
            fecha = new DateTime();
            descripcion = "";
        }

        public int id_Historico { get; set; }
        public Usuario empleado { get; set; }
        public DateTime fecha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Descripción\" es obligatorio.")]
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚñÑ. ]{1,500}$", ErrorMessage = "Los Caracteres especiales no son permitidos y el máximo de caracteres permitidos es 500")]
        public string descripcion { get; set; }
        public int id_inventario { get; set; }
        
    }

    
}
