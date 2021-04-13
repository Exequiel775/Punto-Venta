namespace Servicios.Implementacion.Caja
{
    using Servicios.Interface.Caja;
    using Dapper;
    using Npgsql;
    using Clases.Utiles;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Servicios.Interface.DetalleCaja;

    public class CajaServicio : ICajaServicio
    {
        private readonly NpgsqlConnection _db;

        public CajaServicio(NpgsqlConnection db)
        {
            _db = db;
        }

        public bool AbrirCaja(Caja caja)
        {
            try
            {
                string query = "INSERT INTO Caja(UsuarioAperturaId, MontoApertura, FechaApertura) " +
                "VALUES(@Usuario, @Monto, @Fecha)";

                var parametros = new DynamicParameters();

                parametros.Add("@Usuario", caja.UsuarioAperturaId);
                parametros.Add("@Monto", caja.MontoApertura);
                parametros.Add("@Fecha", caja.FechaApertura);

                _db.Execute(sql: query, param: parametros, commandType: System.Data.CommandType.Text);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CerrarCaja(Caja caja)
        {
            return true;
        }

        public bool ExisteCajaAbierta()
        {
            string query = "SELECT MAX(Id) FROM Caja WHERE FechaCierre IS NULL";

            var resultado = _db.QueryFirstOrDefault<long?>(sql: query, commandType: System.Data.CommandType.Text);

             return resultado.HasValue;
        }

        public IEnumerable<Caja> Get()
        {
            try
            {
                string query = "SELECT Caja.Id, Caja.UsuarioAperturaId, Caja.MontoApertura, Caja.FechaApertura, Caja.UsuarioCierreId, Caja.MontoCierre, " +
                "Caja.CuentaCorrienteEntrada, Caja.CuentaCorrienteSalida, apertura.Nombre AS NombreUsuarioApertura, cierre.Nombre AS NombreUsuarioCierre, " + 
                "SUM(DetalleCaja.Monto) AS TotalEfectivoEntrada FROM Caja " +
                "INNER JOIN Usuario apertura ON apertura.Id = Caja.UsuarioAperturaId " +
                "LEFT JOIN Usuario cierre ON cierre.Id = Caja.UsuarioCierreId " +
                "INNER JOIN DetalleCaja ON Caja.Id = DetalleCaja.CajaId " + 
                "GROUP BY Caja.Id, apertura.Nombre, cierre.Nombre";

                return _db.Query<Caja>(sql: query, commandType: System.Data.CommandType.Text)
                .Select(x => new Caja
                {
                    Id = x.Id,
                    UsuarioAperturaId = x.UsuarioAperturaId,
                    MontoApertura = x.MontoApertura,
                    FechaApertura = x.FechaApertura,
                    NombreUsuarioApertura = x.NombreUsuarioApertura,
                    UsuarioCierreId = x.UsuarioCierreId.HasValue ? x.UsuarioCierreId.Value : -1,
                    NombreUsuarioCierre = x.NombreUsuarioCierre ?? "--",
                    MontoCierre = x.MontoCierre.HasValue ? x.MontoCierre.Value : 0.00m,
                    TotalEfectivoEntrada = x.TotalEfectivoEntrada.HasValue ? x.TotalEfectivoEntrada.Value : 0.00m,
                    CuentaCorrienteEntrada = x.CuentaCorrienteEntrada.HasValue ? x.CuentaCorrienteEntrada.Value : 0.00m,
                    CuentaCorrienteSalida = x.CuentaCorrienteSalida.HasValue ? x.CuentaCorrienteEntrada.Value : 0.00m,
                    FechaCierre = x.FechaCierre
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public long ObtenerCajaAbierta()
        {
            string query = "SELECT MAX(Id) FROM Caja WHERE FechaCierre IS NULL";

            return _db.QueryFirstOrDefault<long>(sql: query, commandType: System.Data.CommandType.Text);
        }
    }
}