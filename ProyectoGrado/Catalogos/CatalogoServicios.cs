using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosDigitalesProy.Models;
using Persistencia.ServiciosDatos;
using Newtonsoft.Json;

namespace ServiciosDigitalesProy.Catalogos
{
    public class CatalogoServicios
    {
        private static CatalogoServicios catalogoServicios = null;
        private static ServiciosDatos serviciosdatos = null;

        public CatalogoServicios()
        {
            serviciosdatos = new ServiciosDatos();
        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoServicios GetInstance()
        {
            if (catalogoServicios == null)
                catalogoServicios = new CatalogoServicios();
            return catalogoServicios;
        }

       
        /// <summary>
        /// envia el servicio a la capa persistencia para su almacenamiento.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarServicio(Servicio servicio, out string resultado, out string tipoResultado)
        {
            serviciosdatos.AgregarServicio( servicio.descripcion,servicio.precio,
                                            out resultado,out tipoResultado);
        }

        
        /// <summary>
        /// Consulta el total de los servicios
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Servicio> ConsultarServicios( ref string resultado, ref string tipoResultado)
        {
            object oUsers;
            string dynObj;
            dynamic dyn;
            List<Servicio> ListaServicios = new List<Servicio>();

            
                oUsers = serviciosdatos.ConsultarServicios(ref resultado, ref tipoResultado);

            dynObj = JsonConvert.SerializeObject(oUsers);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {
                ListaServicios.Add(new Servicio
                {
                    id_servicio = item.id_servicio,
                    descripcion = item.descripcion_servicio,
                    precio = item.precio
                });
            }

            return ListaServicios;
        }


        public List<Servicio> ConsultarServicio(int id,ref string resultado, ref string tipoResultado)
        {
            object oUsers;
            string dynObj;
            dynamic dyn;
            List<Servicio> ListaServicios = new List<Servicio>();


            oUsers = serviciosdatos.ConsultarServicio(id,ref resultado, ref tipoResultado);

            dynObj = JsonConvert.SerializeObject(oUsers);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {
                ListaServicios.Add(new Servicio
                {
                    id_servicio = id,
                    descripcion = item.descripcion_servicio,
                    precio = item.precio
                });
            }

            return ListaServicios;
        }

        /// <summary>
        /// Modifica el producto traido desde el controlador
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void ModificarServicio(Servicio servicio, ref string res, ref string tipoRes)
        {
            serviciosdatos.ModificarServicio
                                        (
                                            servicio.id_servicio,  servicio.descripcion,servicio.precio,
                                            ref res, ref tipoRes
                                        );
        }

     
    }


}