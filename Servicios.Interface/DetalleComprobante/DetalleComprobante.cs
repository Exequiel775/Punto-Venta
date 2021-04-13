namespace Servicios.Interface.DetalleComprobante
{
    using EntityBase;
    public class DetalleComprobante : Base
    {
        public long ComprobanteId { get; set; }
        public long ArticuloId { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Iva { get; set; }
        public decimal Total => decimal.Round(Precio + Iva, 2);
        // USADO EN ARTICULOS MAS VENDIDOS
        public int TotalVendido { get; set; }
    }
}