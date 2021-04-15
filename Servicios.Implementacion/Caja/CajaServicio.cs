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
    using Slapper;

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
                /*
                string query = "SELECT Caja.Id, Caja.UsuarioAperturaId, Caja.MontoApertura, Caja.FechaApertura, Caja.UsuarioCierreId, Caja.MontoCierre, " +
                "Caja.CuentaCorrienteEntrada, Caja.CuentaCorrienteSalida, apertura.Nombre AS NombreUsuarioApertura, cierre.Nombre AS NombreUsuarioCierre, " + 
                "SUM(DetalleCaja.Monto) AS TotalEfectivoEntrada FROM Caja " +
                "INNER JOIN Usuario apertura ON apertura.Id = Caja.UsuarioAperturaId " +
                "LEFT JOIN Usuario cierre ON cierre.Id = Caja.UsuarioCierreId " +
                "INNER JOIN DetalleCaja ON Caja.Id = DetalleCaja.CajaId " + 
                "GROUP BY Caja.Id, apertura.Nombre, cierre.Nombre";*/

                var queryMapeado = _db.Query<dynamic>(sql: "SELECT caja.id as id, caja.usuarioAperturaId, caja.montoapertura, " + 
                "caja.fechaApertura, caja.usuarioCierreId, caja.fechacierre, caja.montocierre, caja.totalefectivoentrada, " +
                "caja.cuentacorrienteentrada, caja.cuentacorrientesalida, detallecaja.cajaid as DetalleCajas_CajaId, " +
                "detalleCaja.monto as DetalleCajas_Monto, detalleCaja.tipopago as DetalleCajas_TipoPago FROM caja " +
                "INNER JOIN detallecaja ON detallecaja.cajaid = caja.id");

                AutoMapper.Configuration.AddIdentifier(typeof(Caja), "id");
                AutoMapper.Configuration.AddIdentifier(typeof(DetalleCaja), "Monto");

                var cajas = (AutoMapper.MapDynamic<Caja>(queryMapeado) as IEnumerable<Caja>).ToList();


                return cajas.Select(x => new Caja
                {
                    Id = x.Id,
                    UsuarioAperturaId = x.UsuarioAperturaId,
                    MontoApertura = x.MontoApertura,
                    FechaApertura = x.FechaApertura,
                    NombreUsuarioApertura = x.NombreUsuarioApertura,
                    UsuarioCierreId = x.UsuarioCierreId.HasValue ? x.UsuarioCierreId.Value : -1,
                    NombreUsuarioCierre = x.NombreUsuarioCierre ?? "--",
                    MontoCierre = x.MontoCierre.HasValue ? x.MontoCierre.Value : 0.00m,
                    TotalEfectivoEntrada = x.DetalleCajas.Where(t => t.TipoPago == TipoPago.Efectivo).Sum(d => d.Monto),//x.TotalEfectivoEntrada.HasValue ? x.TotalEfectivoEntrada.Value : 0.00m,
                    CuentaCorrienteEntrada = x.CuentaCorrienteEntrada.HasValue ? x.CuentaCorrienteEntrada.Value : 0.00m,
                    CuentaCorrienteSalida = x.DetalleCajas.Where(c => c.TipoPago == TipoPago.Cuenta_Corriente).Sum(d => d.Monto)//x.CuentaCorrienteSalida.HasValue ? x.CuentaCorrienteEntrada.Value : 0.00m,
                }).ToList();
                /*
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
                }).ToList();*/
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