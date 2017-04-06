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
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.DETALLE_FACTURA = new HashSet<DETALLE_FACTURA>();
            this.ESCALADO = new HashSet<ESCALADO>();
            this.FACTURA = new HashSet<FACTURA>();
            this.HISTORICO = new HashSet<HISTORICO>();
            this.SOLICITUD = new HashSet<SOLICITUD>();
            this.TELEFONO_USUARIO = new HashSet<TELEFONO_USUARIO>();
            this.DETALLE_FACTURA_PRODUCTO = new HashSet<DETALLE_FACTURA_PRODUCTO>();
            this.DETALLE_FACTURA_SOLICITUD = new HashSet<DETALLE_FACTURA_SOLICITUD>();
        }
    
        public int id_usuario { get; set; }
        public int id_tipo_Identificacion_usuario { get; set; }
        public int id_estado_usuario { get; set; }
        public int id_rol_usuario { get; set; }
        public string identificacion { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string sexo { get; set; }
        public string usuario_login { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACTURA> DETALLE_FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESCALADO> ESCALADO { get; set; }
        public virtual ESTADO_USUARIO ESTADO_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICO> HISTORICO { get; set; }
        public virtual ROL ROL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLICITUD> SOLICITUD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TELEFONO_USUARIO> TELEFONO_USUARIO { get; set; }
        public virtual TIPO_IDENTIFICACION_USUARIO TIPO_IDENTIFICACION_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACTURA_PRODUCTO> DETALLE_FACTURA_PRODUCTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACTURA_SOLICITUD> DETALLE_FACTURA_SOLICITUD { get; set; }
    }
}
