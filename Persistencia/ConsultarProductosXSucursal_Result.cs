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
    
    public partial class ConsultarProductosXSucursal_Result
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public int cantidad_existencias { get; set; }
        public string descripcion_estado_producto { get; set; }
        public System.DateTime fecha_actualizacion_inventario { get; set; }
        public int id_sucursal { get; set; }
        public string nombre { get; set; }
        public int id_inventario { get; set; }
    }
}