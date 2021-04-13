namespace Servicios.Interface.Configuracion
{
    using EntityBase;
    public class Configuracion : Base
    {
        public int LocalidadId { get; set; }
        public int ListaPrecioPorDefectoId { get; set; }
        public long ClientePorDefectoId { get; set; }
        public string RazonSocial { get; set; }
        public int Cuit { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string LocalidadDescripcion { get; set; }
    }
}