using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.CAAM.Admin.Models.Entidades
{
    public class usuarios
    {
        public long usuario_id { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int rol_id { get; set; }
        public bool activo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int? institucion_id { get; set; }
        public string telefono { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string colonia { get; set; }
        public string cp { get; set; }
        public string municipio { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public DateTime? fecha { get; set; }
        public int central_id { get; set; }
        public string refresh_token { get; set; }
        public bool guardia { get; set; }
        public int usuario_siaj { get; set; }
        public string salt { get; set; }
        public DateTime? expira_salt { get; set; }
        public string fcm_token { get; set; }
        public string perfil_nombre_archivo { get; set; }
        public int ciudad_id { get; set; }
        public string curp { get; set; }
        public string empno { get; set; }
        public string genero { get; set; }
    }
}
