//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiciosDigitalesProy.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class FACTURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACTURA()
        {
            this.DETALLE_FACTURA = new HashSet<DETALLE_FACTURA>();
            this.SOLICITUD = new HashSet<SOLICITUD>();
        }
    
        public int id_factura { get; set; }
        public System.DateTime fecha { get; set; }
        public int id_usuario_factura { get; set; }
        public int id_estado_factura { get; set; }
        public decimal abono { get; set; }
        public decimal guardar_total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACTURA> DETALLE_FACTURA { get; set; }
        public virtual ESTADO_FACTURA ESTADO_FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLICITUD> SOLICITUD { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
