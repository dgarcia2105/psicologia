
using System.Collections.Generic;

namespace MM.CAAM.Admin.DTOs
{
    public class InfoHomeDto
    {
        public string Titulo { get; set; }
        public List<string> Contenidos { get; set; } = new List<string>();
    }
}
