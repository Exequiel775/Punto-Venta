namespace Servicios.Interface.Articulos
{
    using EntityBase;
    public class Articulo : Base
    {
        public long IvaId { get; set; }
        public long RubroId { get; set; }
        public long MarcaId { get; set; }
        public int Codigo { get; set; }
        public int CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioPublico { get; set; }
        public string Foto { get; set; }
    }
}