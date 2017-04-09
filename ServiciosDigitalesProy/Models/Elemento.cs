using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Elemento
    {
        public Elemento()
        {
            id_elemento = 0;
            serial = "";
            placa = "";
            modelo = "";
            marca = "";
            ram = "";
            rom = "";
            serialBateria = "";
            SO = "";
            tipoElemento = new TipoElemento();
            categoriaElemento = new CategoriaElemento();
        }

        public Elemento(string descripcionElemento,string serial, string modelo, string marca)
        {
            this.serial = serial;
            this.modelo = modelo;
            this.marca = marca;
            this.tipoElemento = new TipoElemento(descripcionElemento);
        }
        public int id_elemento { get; set; }
        public string serial { get; set; }
        public string placa { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string ram { get; set; }
        public string rom { get; set; }
        public string serialBateria { get; set; }
        public string SO { get; set; }
        public TipoElemento tipoElemento { get; set; }
        public CategoriaElemento categoriaElemento { get; set; }
        public SelectList tiposElementoSelect { get; set; }
        public SelectList categoriasElementoSelect { get; set; }
    }

    
}
