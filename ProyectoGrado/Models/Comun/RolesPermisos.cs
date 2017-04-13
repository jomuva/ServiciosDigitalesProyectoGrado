using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Comun
{
public enum RolesPermisos
{
        #region Clientes
            Puede_crear_nuevo_cliente = 1,
            Puede_modificar_cliente = 2,
            Puede_consultar_cliente = 3,
            Puede_cambiar_estado_cliente = 4,
        #endregion

        #region Empleado
            Puede_crear_nuevo_empleado = 5,
            Puede_modificar_empleado = 6,
            Puede_consultar_empleado = 7,
            Puede_cambiar_estado_empleado = 8,
        #endregion

        #region Producto
            Puede_crear_nuevo_producto = 9,
            Puede_modificar_producto = 10,
            Puede_consultar_producto = 11,
            Puede_cambiar_estado_producto = 12,
        #endregion

        #region Servicio
            Puede_crear_nuevo_servicio = 13,
            Puede_modificar_servicio = 14,
            Puede_consultar_servicio = 15,
        #endregion

        #region Solicitud
            Puede_crear_nuevo_elemento = 16,
            Puede_consultar_solicitud = 17,
            Puede_cambiar_estado_solicitud = 18,
            Puede_escalar_solicitud = 19,
            Puede_consultar_historico_solicitud = 20,
            Puede_agregar_anotacion_historico = 21,
            Puede_crear_solicitud = 22,
            Puede_Ver_Columna_Empleado_Asignado = 30,
        #endregion

        #region Inventario
        Puede_agregar_inventario = 23,
            Puede_consultar_inventario = 24,
            Puede_modificar_inventario = 25,
            Puede_asignar_inventario_sucursal = 26,
        #endregion

        #region Venta
            Puede_agregar_factura = 27,
            Puede_agregar_detalle_factura = 28,
            Puede_consultar_factur = 29,
        #endregion


    }
}