namespace Servicios.Interface.Localidad
{
    using EntityBase;
    public class Localidad : Base
    {
        public long ProvinciaId { get; set; }
        public string Descripcion { get; set; }
        public string Provincia { get; set; }
    }
}