using Models.Comun;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class Permiso
    {
        public Permiso()
        {
            idPermiso = 0;
            Descripcion = "";
        }
        public RolesPermisos PermisoID { get; set; }
        public int idPermiso { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
