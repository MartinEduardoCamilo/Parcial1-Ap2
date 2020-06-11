using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage ="El campo descripcón no debe estar vació")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="El campo existencia no debe estar vació")]
        [MinLength(0,ErrorMessage ="La existencia no puede ser menor que cero")]
        public int Existencia { get; set; }

        [Required(ErrorMessage ="El campo Costo no debe estar vacio")]
        [MinLength(0,ErrorMessage ="Los costo no debe ser menor que cero")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage ="El campo inventario no debe estar vació")]
        [MinLength(0,ErrorMessage ="El campo inventario no debe ser menor que cero")]
        public decimal Inventario { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty; 
            Existencia = 0;
            Costo = 0;
            Inventario = 0;
        }
    }

    

}
