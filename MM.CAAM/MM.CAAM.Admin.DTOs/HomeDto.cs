
using System.Collections.Generic;

namespace MM.CAAM.Admin.DTOs
{
    public class HomeDto
    {
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Title { get; set; }
        public string Eslogan { get; set; }


        public string UrlRedSocialPrincipal { get; set; }
        public string TextRedSocialPrincipal { get; set; }


        public List<InfoHomeDto> ListInfoHome { get; set; } = new List<InfoHomeDto>();
        public ContactoDto Contacto { get; set; }
        public List<RedSocialDto> ListRedSocial { get; set; } = new List<RedSocialDto>();
    }
}
