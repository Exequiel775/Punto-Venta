namespace Servicios.Interface.DetalleComprobante
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    public interface IDetalleComprobanteServicio
    {
        Task<IEnumerable<DetalleComprobante>> GetByCompropante(long comprobante);
        IEnumerable<DetalleComprobante> MasVendidos();
    }
}