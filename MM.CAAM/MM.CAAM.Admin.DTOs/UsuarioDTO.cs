
namespace MM.CAAM.Admin.DTOs
{
    public class UsuarioDTO
    {
        //[StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
