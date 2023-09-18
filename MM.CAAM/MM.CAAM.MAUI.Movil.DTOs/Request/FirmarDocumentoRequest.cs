using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.CAAM.MAUI.Movil.DTOs.Request
{
    public class FirmarDocumentoRequest
    {
        public int ObjectId { get; set; }
        public string TypeObject { get; set; }
        public object DataObject { get; set; }
        public string ContraseniaFirec { get; set; }
        public bool GuardarContrasenia { get; set; }
    }
}
