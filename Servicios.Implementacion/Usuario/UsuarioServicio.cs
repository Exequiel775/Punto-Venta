namespace Servicios.Implementacion.Usuario
{
    using Servicios.Interface.Usuario;
    using Servicios.Interface.Persona;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Dapper;
    using Npgsql;
    using System.Linq;
    using System;
    using System.Data;
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly NpgsqlConnection _db;

        public UsuarioServicio(NpgsqlConnection db)
        {
            _db = db;
        }
        public async Task<bool> BloquearUsuarios(List<Usuario> usuarios)
        {
            if (!usuarios.Any()) return false;

            _db.Open();

            using (var transaccion = await _db.BeginTransactionAsync())
            {

                try
                {
                    foreach (var item in usuarios)
                    {
                        string query = "UPDATE Usuario SET EstaBloqueado = @Bloqueado WHERE Id = @ID";

                        var parametros = new DynamicParameters();
                        parametros.Add("@Bloqueado", item.EstaBloqueado ? false : true);
                        parametros.Add("@ID", item.Id);

                        await _db.ExecuteAsync(query, param: parametros, transaction: transaccion,
                        commandType: System.Data.CommandType.Text);
                    }

                    await transaccion.CommitAsync();

                    _db.Close();

                    return true;
                }
                catch(Exception e)
                {
                    await transaccion.RollbackAsync();
                    _db.Close();
                    throw new Exception($"{e.Message}");
                }
            }
        }

            public async Task<bool> CrearUsuario(List<EmpleadoDto> empleados)
            {
                _db.Open();

                using (var t = await _db.BeginTransactionAsync())
                {
                    try
                    {
                        foreach (var empleado in empleados)
                        {
                            string query = "INSERT INTO Usuario(PersonaId, Nombre, Password, EstaBloqueado) " +
                            "VALUES(@Persona, @Nombre, @Password, @EstaBloqueado)";

                            var parametros = new DynamicParameters();
                            parametros.Add("@Persona", empleado.Id);
                            parametros.Add("@Nombre", await ObtenerNombreUsuario(empleado.Nombre, empleado.Apellido));
                            parametros.Add("@Password", "P$assword");
                            parametros.Add("@EstaBloqueado", false);

                            _db.Execute(sql: query, param: parametros, transaction: t, commandType: CommandType.Text);
                        }

                        await t.CommitAsync();

                        _db.Close();

                        return true;
                    }
                    catch (Exception e)
                    {
                        await t.DisposeAsync();
                        _db.Close();
                        throw new Exception($"Ocurrio este error: {e.Message}");
                    }
                }
            }

            public async Task<IEnumerable<Usuario>> Get()
            {
                string query = "SELECT Usuario.Id, Usuario.PersonaId, Usuario.Nombre, Usuario.EstaBloqueado, Persona.Nombre AS NombrePersona, " +
                "Persona.Apellido AS ApellidoPersona FROM Usuario " +
                "INNER JOIN Persona ON Persona.Id = Usuario.PersonaId";

                return await _db.QueryAsync<Usuario>(sql: query, commandType: CommandType.Text);
            }

            public async Task<Usuario> GetByUser(string usuario)
            {
                string query = "SELECT Usuario.Id, Usuario.PersonaId, Usuario.Nombre, Usuario.EstaBloqueado, Persona.Nombre AS NombrePersona, Persona.Apellido AS ApellidoPersona FROM Usuario " +
                "INNER JOIN Persona ON Persona.Id = Usuario.PersonaId " +
                "WHERE Usuario.Nombre = @NombreUsuario";

                var parametro = new DynamicParameters();
                parametro.Add("@NombreUsuario", usuario);

                return await _db.QueryFirstOrDefaultAsync<Usuario>(sql: query, param: parametro,
                commandType: System.Data.CommandType.Text);
            }

            public async Task<bool> VerificarAcceso(string usuario, string password)
            {
                string query = "SELECT Nombre, Password FROM Usuario WHERE Nombre = @User AND Password = @Pw";

                var parametros = new DynamicParameters();
                parametros.Add("@User", usuario);
                parametros.Add("@Pw", password);

                var resultado = await _db.QueryAsync<Usuario>(sql: query, param: parametros, commandType:
                System.Data.CommandType.Text);

                return resultado.Any();
            }

            public async Task<bool> VerificarBloqueo(string usuario)
            {
                string query = "SELECT EstaBloqueado FROM Usuario WHERE Nombre = @Usuario";

                var parametro = new DynamicParameters();

                parametro.Add("@Usuario", usuario);

                return await _db.QueryFirstOrDefaultAsync<bool>(sql: query, param: parametro,
                commandType: System.Data.CommandType.Text);
            }

            private async Task<string> ObtenerNombreUsuario(string nombre, string apellido)
            {
                int contadorLetras = 1;

                string nombreUsuario = $"{nombre.Trim().ToLower().Substring(0, contadorLetras)}{apellido.Trim().ToLower()}";

                var usuarios = await Get();

                while (usuarios.Any(x => x.Nombre == nombreUsuario))
                {
                    contadorLetras++;

                    nombreUsuario = $"{nombre.Trim().ToLower().Substring(0, contadorLetras)}{apellido.Trim().ToLower()}";
                }

                return nombreUsuario;
            }
        }
    }