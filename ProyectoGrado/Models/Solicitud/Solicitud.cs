using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Solicitud
    {
        public Solicitud()
        {
            id_solicitud = 0;
            prioridadSolicitud = new PrioridadSolicitud();
            estadoSolicitud = new EstadoSolicitud();
            cliente = new Usuario();
            servicio = new Servicio();
            elemento = new Elemento();
            fecha = new DateTime();
            descripcion = "";
            Empleado = "";
            idEmpleado = 0;
            TieneElemento = 0;
        }

        public Solicitud(Servicio servicio)
        {
            this.servicio = new Servicio(servicio.descripcion);
        }

        public int id_solicitud { get; set; }
        public PrioridadSolicitud prioridadSolicitud { get; set; }
        public EstadoSolicitud estadoSolicitud { get; set; }
        public Usuario cliente { get; set; }
        public Servicio servicio { get; set; }
        public Elemento elemento { get; set; }
        public DateTime fecha { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,300}$", ErrorMessage = "Los Caracteres especiales no son permitidos y su tamaño debe ser menos de 300 caracteres")]
        public string descripcion { get; set; }
        public string Empleado { get; set; }
        public int idEmpleado { get; set; }
        #region Atributos Consulta Vista
        public SelectList prioridadSolicitudSelect { get; set; }
        public SelectList estadoSolicitudSelect { get; set; }
        public SelectList ListaEmpleadosSelect { get; set; }
        public SelectList ListaServiciosSelect { get; set; }
        public SelectList ListaClientesSelect { get; set; }
        public int TieneElemento { get; set; }
        #endregion

    }

    
}
