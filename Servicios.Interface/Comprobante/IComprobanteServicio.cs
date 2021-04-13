namespace Servicios.Interface.Comprobante
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    public interface IComprobanteServicio
    {
        Task<long> ObtenerSiguienteNumeroComprobante();
        Task<bool> Facturar(Comprobante comprobante);
        Task<IEnumerable<Comprobante>> GetByCliente(long cliente);
        Task<Comprobante> GetById(long comprobante);
        IEnumerable<Comprobante> EmpleadosQueMasVendieron();
    }
}