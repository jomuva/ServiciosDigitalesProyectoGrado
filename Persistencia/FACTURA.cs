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
    
    public partial class FACTURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACTURA()
        {
            this.DETALLE_FACTURA_PRODUCTO = new HashSet<DETALLE_FACTURA_PRODUCTO>();
            this.DETALLE_FACTURA_SOLICITUD = new HashSet<DETALLE_FACTURA_SOLICITUD>();
            this.HISTORICO_FACTURA = new HashSet<HISTORICO_FACTURA>();
        }
    
        public int id_factura { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<int> id_cliente_factura { get; set; }
        public Nullable<int> id_empleado_factura { get; set; }
        public int id_estado_factura { get; set; }
        public Nullable<decimal> saldo { get; set; }
        public Nullable<decimal> valor_total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACTURA_PRODUCTO> DETALLE_FACTURA_PRODUCTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACTURA_SOLICITUD> DETALLE_FACTURA_SOLICITUD { get; set; }
        public virtual ESCALADO ESCALADO { get; set; }
        public virtual ESTADO_FACTURA ESTADO_FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICO_FACTURA> HISTORICO_FACTURA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
