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
    
    public partial class TIPO_ELEMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_ELEMENTO()
        {
            this.ELEMENTO = new HashSet<ELEMENTO>();
        }
    
        public int id_tipo_elemento { get; set; }
        public string descripcion_elemento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ELEMENTO> ELEMENTO { get; set; }
    }
}
