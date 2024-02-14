namespace MM.CAAM.Gestion.Models.Entidades.Catalogos
{
    public class Tipo
    {
        public int Id { get; set; }
        public int TipoGrupoId { get; set; }
        public int Orden { get; set; }
        public string Descripcion { get; set; }
        //public float? Costo { get; set; }                //TODO: investigar mejor forma para un precio
        //public int? ProveedorId { get; set; }           
        //public int? GrupoAlimenticioId { get; set; }   
        //public int? SeccionSupermercado { get; set; } 
        //public int? UnidadMedidaId { get; set; }
    }
}
