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
    
    public partial class PRIORIDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRIORIDAD()
        {
            this.SOLICITUD = new HashSet<SOLICITUD>();
        }
    
        public int id_prioridad { get; set; }
        public string descripcion_prioridad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLICITUD> SOLICITUD { get; set; }
    }
}
