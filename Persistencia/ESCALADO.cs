//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistencia
{
    using System;
    using System.Collections.Generic;
    
    public partial class ESCALADO
    {
        public int id_escalado { get; set; }
        public Nullable<int> id_solicitud_escalado { get; set; }
        public Nullable<int> id_usuario_escalado { get; set; }
    
        public virtual SOLICITUD SOLICITUD { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
