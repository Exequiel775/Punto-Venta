namespace Servicios.Implementacion.Persona
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Servicios.Interface.Persona;
    using Dapper;
    using Npgsql;
    using System;
    public class ClienteServicio : PersonaServicio, IClienteServicio
    {
        public async Task<bool> ActivarDesactivarCuenta(List<ClienteDto> clientes)
        {
            using (var _db = new NpgsqlConnection("Server=localhost; User Id=postgres;Password=panchito; DataBase=SistemaVentas"))
            {
                _db.Open();

                using (var t = await _db.BeginTransactionAsync())
                {
                    try
                    {
                        foreach (var item in clientes)
                        {
                            string query = "SELECT * FROM Persona WHERE Id = @ID AND Discriminador = @Discriminador";
                            var parametro = new DynamicParameters();

                            parametro.Add("@ID", item.Id);
                            parametro.Add("@Discriminador", "Cliente");

                            var cliente = _db.QueryFirstOrDefault<ClienteDto>(query, param: parametro,
                            transaction: t, commandType: System.Data.CommandType.Text);

                            string actualizarEstado = "UPDATE Persona SET ActivarCtaCte = @NuevoEstado WHERE Id = @ID " +
                            "AND Discriminador = @Discriminador";
                            var parametroActualizar = new DynamicParameters();

                            parametroActualizar.Add("@NuevoEstado", cliente.ActivarCtaCte ? false : true);
                            parametroActualizar.Add("@ID", cliente.Id);
                            parametroActualizar.Add("@Discriminador", "Cliente");

                            _db.Execute(actualizarEstado, param: parametroActualizar,
                            transaction: t, commandType: System.Data.CommandType.Text);
                        }

                        await t.CommitAsync();

                        _db.Close();

                        return true;
                    }
                    catch (Exception e)
                    {
                        await t.RollbackAsync();
                        _db.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
    }

    
}