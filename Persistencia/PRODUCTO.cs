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
    
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.DETALLE_FACTURA_PRODUCTO = new HashSet<DETALLE_FACTURA_PRODUCTO>();
            this.INVENTARIO = new HashSet<INVENTARIO>();
            this.INVENTARIO_BAJAS = new HashSet<INVENTARIO_BAJAS>();
        }
    
        public int id_producto { get; set; }
        public int id_estado_producto { get; set; }
        public int id_categoria_producto { get; set; }
        public string nombre_producto { get; set; }
        public Nullable<decimal> precio_costo { get; set; }
        public Nullable<decimal> precio_venta { get; set; }
    
        public virtual CATEGORIA_PRODUCTO CATEGORIA_PRODUCTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACTURA_PRODUCTO> DETALLE_FACTURA_PRODUCTO { get; set; }
        public virtual ESTADO_PRODUCTO ESTADO_PRODUCTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTARIO> INVENTARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTARIO_BAJAS> INVENTARIO_BAJAS { get; set; }
    }
}
