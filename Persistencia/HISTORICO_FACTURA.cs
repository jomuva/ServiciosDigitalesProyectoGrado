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
    
    public partial class HISTORICO_FACTURA
    {
        public int id_historico { get; set; }
        public int id_empleado_historico { get; set; }
        public int id_factura_historico { get; set; }
        public string descripcion_historico { get; set; }
        public Nullable<System.DateTime> fecha_historico { get; set; }
    
        public virtual FACTURA FACTURA { get; set; }
    }
}
