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
    
    public partial class ELEMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ELEMENTO()
        {
            this.SERVICIO_ELEMENTO = new HashSet<SERVICIO_ELEMENTO>();
        }
    
        public int id_elemento { get; set; }
        public string serial { get; set; }
        public string placa { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string ram { get; set; }
        public string rom { get; set; }
        public string serial_bateria { get; set; }
        public string sistema_operativo { get; set; }
        public int id_tipo_elemento { get; set; }
        public int id_categoria_elemento { get; set; }
    
        public virtual CATEGORIA_ELEMENTO CATEGORIA_ELEMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICIO_ELEMENTO> SERVICIO_ELEMENTO { get; set; }
        public virtual TIPO_ELEMENTO TIPO_ELEMENTO { get; set; }
    }
}