using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Elemento
    {
        public Elemento()
        {
            id_elemento = 1;
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

        public Elemento(string descripcionCategoria,string descripcionElemento,string serial, string placa,string modelo, string marca,string ram,string rom,string serial_bateria,string sistema_operativo)
        {
            this.serial = serial;
            this.modelo = modelo;
            this.marca = marca;
            this.tipoElemento = new TipoElemento(descripcionElemento);
            this.categoriaElemento = new CategoriaElemento(descripcionCategoria);
        }

        public int id_elemento { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Serial\" es obligatorio.")]
        public string serial { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string placa { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string modelo { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string marca { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string ram { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string rom { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string serialBateria { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        public string SO { get; set; }
        public TipoElemento tipoElemento { get; set; }
        public CategoriaElemento categoriaElemento { get; set; }
        public SelectList tiposElementoSelect { get; set; }
        public SelectList categoriasElementoSelect { get; set; }
    }

    
}
