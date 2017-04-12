using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosDigitalesProy.Models;
using Persistencia.SolicitudesDatos;
using Newtonsoft.Json;

namespace ServiciosDigitalesProy.Catalogos
{
    public class CatalogoSolicitudes
    {
        private static CatalogoSolicitudes catalogoSolicitudes = null;
        private static SolicitudesDatos solicitudesDatos = null;

        public CatalogoSolicitudes()
        {
            solicitudesDatos = new SolicitudesDatos();
        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoSolicitudes GetInstance()
        {
            if (catalogoSolicitudes == null)
                catalogoSolicitudes = new CatalogoSolicitudes();
            return catalogoSolicitudes;
        }

        #region Elemento

        /// <summary>
        /// Consulta los tipos de elemento y los convierte a modelo 
        /// </summary>
        /// <returns></returns>
        public List<TipoElemento> ConsultarTiposElemento()
        {
            List<TipoElemento> Tipos = new List<TipoElemento>();
            var tipos = solicitudesDatos.ConsultarTiposElemento();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Tipos.Add(new TipoElemento
                {
                    id = data.id_tipo_elemento,
                    Descripcion = data.descripcion_elemento,
                });
            }

            return Tipos;
        }

        /// <summary>
        /// Consulta las categorias de elemento y las convierte a modelo
        /// </summary>
        /// <returns></returns>
        public List<CategoriaElemento> ConsultarCategoriasElemento()
        {
            List<CategoriaElemento> Tipos = new List<CategoriaElemento>();
            var tipos = solicitudesDatos.ConsultarCategoriasElemento();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Tipos.Add(new CategoriaElemento
                {
                    id = data.id_categoria_elemento,
                    Descripcion = data.descripcion_categoria_elemento,
                });
            }

            return Tipos;
        }
        /// <summary>
        /// Envia informacion a la capa de persistencia para adicionar un elemento
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarElemento(Elemento elemento, ref string resultado, ref string tipoResultado)
        {
            solicitudesDatos.AgregarElemento(
                                                elemento.serial, elemento.placa, elemento.modelo, elemento.marca, elemento.ram,
                                                elemento.rom, elemento.serialBateria, elemento.SO,
                                                elemento.tipoElemento.id, elemento.categoriaElemento.id,
                                                ref resultado, ref tipoResultado
                                                );
        }

        #endregion
        /// <summary>
        /// Consulta el total de solicitudes y en este metodo los convierte a Objeto Solicitud
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Solicitud> ConsultarSolicitudes(ref string resultado, ref string tipoResultado)
        {
            object oSolicitudes;
            string dynObj;
            dynamic dyn;
            List<Solicitud> ListaSolicitudes = new List<Solicitud>();

            oSolicitudes = solicitudesDatos.ConsultarSolicitudes(ref resultado, ref tipoResultado);

            dynObj = JsonConvert.SerializeObject(oSolicitudes);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {
                ListaSolicitudes.Add(new Solicitud
                {
                    cliente = new Usuario((string)item.identificacion, (string)item.apellidos, (string)item.nombres),
                    id_solicitud = item.id_solicitud,
                    descripcion = item.descripcion,
                    fecha = item.fecha_solicitud,
                    prioridadSolicitud = new PrioridadSolicitud((string)item.descripcion_prioridad),
                    estadoSolicitud = new EstadoSolicitud((string)item.Estado),
                    elemento = new Elemento((string)item.descripcion_elemento,(string)item.serial,(string)item.modelo,(string)item.marca),
                    servicio = new Servicio((string)item.descripcion_servicio)            
                });
            }

            return ListaSolicitudes;
        }


        

        /// <summary>
        /// Agrega una solicitud y verificar si la solicitud tiene un elemento para agregar o no
        /// </summary>
        /// <returns></returns>
        public void GenerarSolicitud(Solicitud solicitud, ref string resultado, ref string tipoResultado)
        {

            solicitudesDatos.GenerarSolicitud(
                                                solicitud.prioridadSolicitud.id,solicitud.estadoSolicitud.id,
                                                solicitud.cliente.id,solicitud.servicio.id_servicio,solicitud.elemento.id_elemento, 
                                                solicitud.descripcion, ref resultado,ref tipoResultado);
        }

       
    }


}