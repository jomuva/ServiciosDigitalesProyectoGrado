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

        public bdServiciosDigitalesProyEntities conexiones;
        public object instance;
        public conexion()
        {
            this.instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            this.conexiones = new bdServiciosDigitalesProyEntities();
        }


    }
}