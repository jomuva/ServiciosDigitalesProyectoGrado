using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia.VentasDatos;
using Newtonsoft.Json;
using ServiciosDigitalesProy.Models;
using Helper;

namespace ProyectoGrado.Catalogos
{
    public class CatalogoVentas
    {
        private static CatalogoVentas catalogoVentas = null;
        private static VentasDatos ventasDatos = null;

        public CatalogoVentas()
        {
            ventasDatos = new VentasDatos();
        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoVentas GetInstance()
        {
            if (catalogoVentas == null)
                catalogoVentas = new CatalogoVentas();
            return catalogoVentas;
        }


        /// <summary>
        /// Consulta el total de inventarios o un inventario de algun producto en especial
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public Factura CrearFacturaSinRegistros(ref string resultado, ref string tipoResultado)
        {
            object oFactura = null;
            string dynObj;
            dynamic dyn;

            oFactura = ventasDatos.CrearFacturaSinRegistros(SessionHelper.GetUser().ToString(), ref resultado, ref tipoResultado);
            Factura factura = new Factura();
            if (tipoResultado != "danger")
            {
                dynObj = JsonConvert.SerializeObject(oFactura);
                dyn = JsonConvert.DeserializeObject(dynObj);
               
                foreach (var item in dyn)
                {
                    factura.id_factura = item.id_factura;
                    factura.fecha = item.fecha;

                }
            }
            return factura;
        }


        /// <summary>
        /// TRAE EL ID DE LA ULTIMA FACTURA CREADA
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public int ObtenerIdUltimaFacturaGenerada(ref string resultado, ref string tipoResultado)
        {
            object oFactura = null;
            string dynObj;
            dynamic dyn;

            oFactura = ventasDatos.ObtenerIdUltimaFacturaGenerada(ref resultado, ref tipoResultado);
            int id = 0;
            if (tipoResultado != "danger")
            {
                dynObj = JsonConvert.SerializeObject(oFactura);
                dyn = JsonConvert.DeserializeObject(dynObj);

                foreach (var item in dyn)
                {
                    id = Convert.ToInt32(item);

                }
            }
            return id;
        }
    }
}