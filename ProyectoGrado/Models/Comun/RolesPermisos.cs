using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Comun
{
public enum RolesPermisos
{
        puede_adicionar_servicio = 1,
        puede_consultar_servicio = 2,
        puede_editar_servicio = 3,
        puede_crear_factura = 4,
        puede_consultar_factura = 5,
        puede_anular_factura = 6,
        puede_pagar_factura = 7,
        puede_ver_historico_factura = 8,
        puede_ver_detalle_factura = 9,
        puede_adicionar_cliente = 10,
        puede_consultar_cliente = 11,
        puede_editar_cliente = 12,
        puede_ver_detalles_cliente = 13,
        puede_cambiar_estado_cliente = 14,
        puede_adicionar_empleado = 15,
        puede_editar_empleado = 16,
        puede_ver_detalles_empleado = 17,
        puede_cambiar_estado_empleado = 18,
        puede_adicionar_producto = 19,
        puede_consultar_producto = 20,
        puede_editar_producto = 21,
        puede_cambiar_estado_producto = 22,
        puede_consultar_inventario = 23,
        puede_ver_historico_inventario = 24,
        puede_agregar_anotacion_inventario = 25,
        puede_agregar_existancias_inventario = 26,
        puede_consultar_inventario_bajas = 27,
        puede_ver_historio_inventario_bajas = 28,
        puede_agregar_anotacion_inventario_bajas = 29,
        puede_agregar_bajas_inventario = 30,
        puede_consultar_solicitudes = 31,
        puede_agregar_elemento = 32,
        puede_crear_solicitudes = 33,
        puede_cambiar_estado_solicitud = 34,
        puede_escalar_solicitud = 35,
        puede_ver_detalle_solicitud = 36,
        puede_agregar_anotacion_solicitud = 37,
        puede_consultar_elementos = 38,
        Puede_Ver_Columna_Empleado_Asignado = 39,
        Puede_consultar_empleado = 40,
        Puede_Crear_Sucursal = 41,
        Puede_Trasladar_Producto = 42,
        Puede_Crear_Espacio_En_sucursal = 43,
        Puede_Consultar_Total_Existencias = 44


    }
}