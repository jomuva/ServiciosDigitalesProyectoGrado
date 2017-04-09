using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia
{
    public class conexion
    {

        /// <summary>
        /// Objeto conexionque genera conexion a la base de datos
        /// </summary>

        public bdServiciosDigitalesProyEntities2 conexiones;

        public conexion()
        {
            this.conexiones = new bdServiciosDigitalesProyEntities2();
        }

      
    }
}