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
    
    public partial class DETALLE_FACTURA_SOLICITUD
    {
        public int id_detalle_factura_solicitud { get; set; }
        public Nullable<int> id_solicitud_detalle_factura { get; set; }
        public int id_factura_detalle_factura { get; set; }
        public int cantidad_venta { get; set; }
    
        public virtual FACTURA FACTURA { get; set; }
        public virtual SOLICITUD SOLICITUD { get; set; }
    }
}
