namespace Servicios.Interface.Articulos
{
    using EntityBase;
    public class ArticuloVentaDto : Base
    {
        public long IvaId { get; set; }
        public long RubroId { get; set; }
        public long MarcaId { get; set; }
        public int Codigo { get; set; }
        public int CodigoBarra { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioPublico { get; set; }
        public string Foto { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }
    }
}