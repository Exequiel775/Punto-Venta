namespace Servicios.Implementacion.DetalleComprobante
{
    using Servicios.Interface.DetalleComprobante;
    using Npgsql;
    using Dapper;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class DetalleComprobanteServicio : IDetalleComprobanteServicio
    {
        private readonly NpgsqlConnection _db;

        public DetalleComprobanteServicio(NpgsqlConnection db)
        {
            _db = db;
        }
        public async Task<IEnumerable<DetalleComprobante>> GetByCompropante(long comprobanteId)
        {
            string query = "SELECT Id, ComprobanteId, ArticuloId, Codigo, Descripcion, Cantidad, Precio, Iva " +
            "FROM DetalleComprobante WHERE ComprobanteId = @Comprobante";

            var parametro = new DynamicParameters();
            parametro.Add("@Comprobante", comprobanteId);

            return await _db.QueryAsync<DetalleComprobante>(sql: query, param: parametro, 
            commandType: System.Data.CommandType.Text);
        }

        public IEnumerable<DetalleComprobante> MasVendidos()
        {
            string query = "SELECT Descripcion, SUM(Cantidad) AS TotalVendido FROM DetalleComprobante GROUP BY Descripcion ORDER BY TotalVendido DESC LIMIT 3";

            return _db.Query<DetalleComprobante>(sql: query, commandType: System.Data.CommandType.Text);
        }
    }
}