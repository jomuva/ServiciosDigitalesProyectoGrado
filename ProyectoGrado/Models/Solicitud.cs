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
        }

        public int id_solicitud { get; set; }
        public PrioridadSolicitud prioridadSolicitud { get; set; }
        public EstadoSolicitud estadoSolicitud { get; set; }
        public Usuario cliente { get; set; }
        public Servicio servicio { get; set; }
        public Elemento elemento { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string Empleado { get; set; }
        public int idEmpleado { get; set; }
        public SelectList prioridadSolicitudSelect { get; set; }
        public SelectList estadoSolicitudSelect { get; set; }

    }

    
}
