namespace Servicios.Implementacion.Comprobante
{
    using System.Threading.Tasks;
    using Servicios.Interface.Comprobante;
    using System.Collections.Generic;
    using Npgsql;
    using Dapper;
    using System.Linq;
    using System;
    using Servicios.Interface.Articulos;
    using Servicios.Interface.DetalleComprobante;
    using Clases.Utiles;
    using Servicios.Interface.Caja;
    public class ComprobanteServicio : IComprobanteServicio
    {
        private readonly NpgsqlConnection _db;
        private readonly IArticuloServicio _articuloServicio;
        private readonly ICajaServicio _cajaServicio;
        public ComprobanteServicio(NpgsqlConnection db, IArticuloServicio articuloServicio, ICajaServicio cajaServicio)
        {
            _db = db;
            _articuloServicio = articuloServicio;
            _cajaServicio = cajaServicio;
        }

        public IEnumerable<Comprobante> EmpleadosQueMasVendieron()
        {
            try
            {
                string query = "SELECT Persona.Nombre AS NombreEmpleado, Persona.Apellido AS ApellidoEmpleado, COUNT(EmpleadoId) AS CantidadVendida FROM Comprobante " +
                "INNER JOIN Persona ON Persona.Id = Comprobante.EmpleadoId " +
                "GROUP BY Persona.Nombre, Persona.Apellido ORDER BY CantidadVendida DESC LIMIT 5";

                return _db.Query<Comprobante>(sql: query, commandType: System.Data.CommandType.Text);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Facturar(Comprobante comprobante)
        {
            _db.Open();

            using (var t = await _db.BeginTransactionAsync())
            {
                try
                {
                    string query = "INSERT INTO Comprobante(ClienteId, EmpleadoId, Numero, SubTotal, Total, Descuento, " +
                    "TotalIva, Fecha, TipoComprobante, EstadoComprobante) " +
                    "VALUES(@Cliente, @Empleado, @Numero, @SubTotal, @Total, @Descuento, @TotalIva, @Fecha, @Tipo, @Estado) " +
                    "returning Id;";

                    var parametrosComprobante = new DynamicParameters();

                    var total = comprobante.Items.Sum(x => x.Total * x.Cantidad) - comprobante.Descuento;

                    parametrosComprobante.Add("@Cliente", comprobante.ClienteId);
                    parametrosComprobante.Add("@Empleado", IdentidadUsuarioLogin.EmpleadoId);
                    parametrosComprobante.Add("@Numero", comprobante.Numero);
                    parametrosComprobante.Add("@SubTotal", comprobante.Items.Sum(x => x.Total * x.Cantidad));
                    parametrosComprobante.Add("@Total", total);
                    parametrosComprobante.Add("@Descuento", comprobante.Descuento);
                    parametrosComprobante.Add("@TotalIva", comprobante.Items.Sum(x => x.TotalIva));
                    parametrosComprobante.Add("@Fecha", DateTime.Now);
                    parametrosComprobante.Add("@Tipo", comprobante.TipoComprobante);
                    parametrosComprobante.Add("@Estado", comprobante.EstadoComprobante);

                    var comprobanteId = await _db.QueryFirstOrDefaultAsync<long>(query, param: parametrosComprobante,
                    commandType: System.Data.CommandType.Text, transaction: t);

                    // GRABAMOS EL DETALLE DEL COMPROBANTE

                    foreach (var item in comprobante.Items)
                    {
                        var articulo = _articuloServicio.GetByCodigo(item.Codigo);

                        string queryDetalle = "INSERT INTO DetalleComprobante(ComprobanteId, ArticuloId, Codigo, " +
                        "Descripcion, Cantidad, Precio, Iva) VALUES(@Comprobante, @Articulo, @Codigo, @Descrip, @Cantidad, @Precio, @Iva)";

                        var parametrosDetalle = new DynamicParameters();

                        parametrosDetalle.Add("@Comprobante", comprobanteId);
                        parametrosDetalle.Add("@Articulo", articulo.Id);
                        parametrosDetalle.Add("@Codigo", item.Codigo);
                        parametrosDetalle.Add("@Cantidad", item.Cantidad);
                        parametrosDetalle.Add("@Descrip", articulo.Descripcion);
                        parametrosDetalle.Add("@Precio", articulo.PrecioPublico);
                        parametrosDetalle.Add("@Iva", item.TotalIva);

                        _db.Execute(queryDetalle, param: parametrosDetalle, transaction: t, commandType:
                        System.Data.CommandType.Text);
                    }

                    GrabarMovimientos(comprobanteId, comprobante.Numero, total, t);
                    GrabarDetalleCaja(total, comprobante.TipoPago, t);

                    // Incrementamos la secuencia de postgres para el numero de comprobante
                    _db.Execute("select nextval('seq_numero_comprobante')", commandType:
                    System.Data.CommandType.Text);

                    await t.CommitAsync();

                    _db.Close();

                    return true;
                }
                catch(Exception e)
                {
                    _db.Close();
                    await t.RollbackAsync();
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<IEnumerable<Comprobante>> GetByCliente(long cliente)
        {
            /*
            string sql = "SELECT * FROM Comprobante as comp " +
            "INNER JOIN DetalleComprobante as det ON det.ComprobanteId = comp.Id " +
            "WHERE comp.ClienteId = @Cliente";*/

            string sql = "SELECT Comprobante.Id, Comprobante.ClienteId, Comprobante.EmpleadoId, Comprobante.Numero, " +
            "Comprobante.SubTotal, Comprobante.Total, Comprobante.Descuento, Comprobante.TotalIva, Comprobante.Fecha, " +
            "Comprobante.TipoComprobante, Comprobante.EstadoComprobante, Persona.Nombre AS NombreEmpleado, Persona.Apellido AS ApellidoEmpleado " +
            "FROM Comprobante " +
            "INNER JOIN Persona ON Persona.Id = Comprobante.EmpleadoId " +
            "WHERE Comprobante.ClienteId = @Cliente";

            var parametro = new DynamicParameters();
            parametro.Add("@Cliente", cliente);

            var resultado = (await _db.QueryAsync<Comprobante>(sql, param: parametro, commandType:
            System.Data.CommandType.Text));

            return resultado.Select(x => new Comprobante
            {
                Id = x.Id,
                ClienteId = x.ClienteId,
                Numero = x.Numero,
                SubTotal = x.SubTotal,
                Total = x.Total,
                Descuento = x.Descuento,
                TotalIva = x.TotalIva,
                Fecha = x.Fecha,
                TipoComprobanteInt = x.TipoComprobanteInt,
                EstadoComprobante = x.EstadoComprobante,
                NombreEmpleado = x.NombreEmpleado,
                ApellidoEmpleado = x.ApellidoEmpleado
            }).ToList();
        }

        public async Task<Comprobante> GetById(long comprobante)
        {
            string query = "SELECT * FROM Comprobante WHERE Id = @ID";

            var parametro = new DynamicParameters();
            parametro.Add("@ID", comprobante);

            return await _db.QueryFirstOrDefaultAsync<Comprobante>(sql: query, param: parametro,
            commandType: System.Data.CommandType.Text);
        }

        public async Task<long> ObtenerSiguienteNumeroComprobante()
        {
            string query = "SELECT last_value + 1 FROM seq_numero_comprobante";

            return await _db.QueryFirstOrDefaultAsync<long>(query, commandType: System.Data.CommandType.Text);
        }

        // ===================== METODOS PRIVADOS ========================== //
        private void GrabarMovimientos(long comprobante, long numero, decimal total, NpgsqlTransaction transaccion)
        {
            try
            {
            string query = "INSERT INTO Movimientos(CajaId, ComprobanteId, UsuarioId, Fecha, Descripcion, TipoMovimiento) " +
            "VALUES(@Caja, @Comprobante, @Usuario, @Fecha, @Descrip, @TipoMov)";

            var parametros = new DynamicParameters();
            parametros.Add("@Caja", _cajaServicio.ObtenerCajaAbierta());
            parametros.Add("@Comprobante", comprobante);
            parametros.Add("@Usuario", IdentidadUsuarioLogin.UsuarioId);
            parametros.Add("@Fecha", DateTime.Now);
            parametros.Add("@Descrip", $"{TipoMovimiento.Ingreso} - Nro: {numero} - Total: ${total}");
            parametros.Add("@TipoMov", TipoMovimiento.Ingreso);

            _db.Execute(sql: query, param: parametros, transaction: transaccion, commandType: System.Data.CommandType.Text);
            }
            catch(Exception e)
            {
                transaccion.Rollback();
                throw new Exception(e.Message);
            }
        }

        private void GrabarDetalleCaja(decimal monto, TipoPago tipoPago, NpgsqlTransaction t)
        {
            try
            {
                var caja = _cajaServicio.ObtenerCajaAbierta();

                string query = "INSERT INTO DetalleCaja(CajaId, Monto, TipoPago) VALUES(@Caja, @Monto, @TipoPago)";

                var parametros = new DynamicParameters();
                parametros.Add("@Caja", caja);
                parametros.Add("@Monto", monto);
                parametros.Add("@TipoPago", tipoPago);

                _db.Execute(sql: query, param: parametros, transaction: t, commandType: System.Data.CommandType.Text);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}