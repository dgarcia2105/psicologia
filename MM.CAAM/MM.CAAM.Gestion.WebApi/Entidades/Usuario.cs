using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MM.CAAM.Gestion.WebApi.Validaciones;

namespace MM.CAAM.Gestion.WebApi.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        //[PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        //public List<AutorLibro> AutoresLibros { get; set; }
        public List<Negocio> Negocios { get; set; } //= new List<Negocio>();
        public List<Consulta> Consultas { get; set; }                                   //UNO A MUCHOS [Usuario muchas Consultas][Libro muchos Comentarios]
    
        
    }
}
