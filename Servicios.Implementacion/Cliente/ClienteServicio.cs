namespace Servicios.Implementacion.Cliente
{
    using Servicios.Interface.Cliente;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Dapper;
    using Npgsql;
    using System;
    public class ClienteServicio : IClienteServicio
    {
        private readonly NpgsqlConnection _db;

        public ClienteServicio(NpgsqlConnection db)
        {
            _db = db;
        }

        public async Task<bool> ActivarDesactivarCuenta(List<Cliente> clientes)
        {
            _db.Open();

            using(var t = await _db.BeginTransactionAsync())
            {
                try
                {
                    foreach(var item in clientes)
                    {
                        string query = "SELECT * FROM Persona WHERE Id = @ID";
                        var parametro = new DynamicParameters();

                        parametro.Add("@ID", item.Id);

                        var cliente = _db.QueryFirstOrDefault<Cliente>(query, param: parametro,
                        transaction: t, commandType: System.Data.CommandType.Text);

                        string actualizarEstado = "UPDATE Cliente SET ActivarCtaCte = @NuevoEstado WHERE Id = @ID";
                        var parametroActualizar = new DynamicParameters();

                        parametroActualizar.Add("@NuevoEstado", cliente.ActivarCtaCte ? false : true);
                        parametroActualizar.Add("@ID", cliente.Id);

                        _db.Execute(actualizarEstado, param: parametroActualizar, 
                        transaction: t, commandType: System.Data.CommandType.Text);
                    }

                    await t.CommitAsync();

                    _db.Close();

                    return true;
                }
                catch(Exception e)
                {
                    await t.RollbackAsync();
                    _db.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<bool> Add(Cliente cliente)
        {
            try
            {
                string[] arrayCampos = {cliente.Nombre, cliente.Apellido, 
                cliente.Direccion};

                if (!CamposValidos(arrayCampos)) return false;

                string query = "INSERT INTO Persona(LocalidadId, Nombre, Apellido, Dni, Direccion, " +
                "ActivarCtaCte, TieneLimite, FechaRegistro, LimiteMonto, Discriminador) " + 
                "VALUES(@Localidad, @Nombre, @Apellido, @Dni, @Direccion, @ActivarCta, @TieneLimite, " +
                "@FechaRegistro, @Limite, @Discriminador)";

                var parametros = new DynamicParameters();
                parametros.Add("@Localidad", cliente.LocalidadId);
                parametros.Add("@Nombre", cliente.Nombre);
                parametros.Add("@Apellido", cliente.Apellido);
                parametros.Add("@Dni", cliente.Dni);
                parametros.Add("@Direccion", cliente.Direccion);
                parametros.Add("@ActivarCta", cliente.ActivarCtaCte);
                parametros.Add("@TieneLimite", cliente.TieneLimite);
                parametros.Add("@FechaRegistro", DateTime.Now);
                parametros.Add("@Limite", decimal.Round(cliente.LimiteMonto, 2));
                parametros.Add("@Discriminador", "Cliente");

                await _db.ExecuteAsync(query, param: parametros, commandType: System.Data.CommandType.Text);

                return true;
            }
            catch(System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Cliente> GetById(long id)
        {
            string query = "SELECT * FROM Cliente WHERE Id = @ID";

            var parametro = new DynamicParameters();
            parametro.Add("@ID", id);

            return await _db.QueryFirstOrDefaultAsync<Cliente>(query, param: parametro,
            commandType: System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _db.QueryAsync<Cliente>("SELECT * FROM Persona WHERE Discriminador = @Cliente", 
            param: new { @Cliente = "Cliente" }, commandType: System.Data.CommandType.Text);
        }

        public async Task<bool> Update(Cliente clienteModificar)
        {
            throw new System.NotImplementedException();
        }

        private bool CamposValidos(string[] datos)
        {
            for(int i = 0; i < datos.Length; i ++)
            {
                if (datos[i].Equals(string.Empty)) return false;
            }

            return true;
        }
    }
}