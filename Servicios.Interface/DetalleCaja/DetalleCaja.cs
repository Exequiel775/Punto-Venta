namespace Servicios.Interface.DetalleCaja
{
    using EntityBase;
    using Clases.Utiles;
    public class DetalleCaja : Base
    {
        public long CajaId { get; set; }
        public decimal Monto { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}