
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MM.CAAM.Admin.DTOs.Request
{
    public class GeneroRequest
    {
        public int Id { get; set; }
        public string Genero { get; set; }
    }
}
