
using System.Collections.Generic;

namespace MM.CAAM.Admin.DTOs
{
    public class HomeDto
    {
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Title { get; set; }
        public string Eslogan { get; set; }

        public List<InfoHomeDto> ListInfoHome { get; set; } = new List<InfoHomeDto>();

        public string UrlFacebook { get; set; }
        public string TextFacebook { get; set; }
    }
}
