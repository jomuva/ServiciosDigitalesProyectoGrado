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
            this.ESCALADO = new HashSet<ESCALADO>();
            this.FACTURA = new HashSet<FACTURA>();
            this.HISTORICO_INVENTARIO = new HashSet<HISTORICO_INVENTARIO>();
            this.HISTORICO_INVENTARIO_BAJAS = new HashSet<HISTORICO_INVENTARIO_BAJAS>();
            this.HISTORICO_SOLICITUD = new HashSet<HISTORICO_SOLICITUD>();
            this.SOLICITUD = new HashSet<SOLICITUD>();
            this.TELEFONO_USUARIO = new HashSet<TELEFONO_USUARIO>();
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
        public virtual ICollection<ESCALADO> ESCALADO { get; set; }
        public virtual ESTADO_USUARIO ESTADO_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICO_INVENTARIO> HISTORICO_INVENTARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICO_INVENTARIO_BAJAS> HISTORICO_INVENTARIO_BAJAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICO_SOLICITUD> HISTORICO_SOLICITUD { get; set; }
        public virtual ROL ROL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLICITUD> SOLICITUD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TELEFONO_USUARIO> TELEFONO_USUARIO { get; set; }
        public virtual TIPO_IDENTIFICACION_USUARIO TIPO_IDENTIFICACION_USUARIO { get; set; }
    }
}
