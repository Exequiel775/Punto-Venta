namespace Servicios.Implementacion.Persona
{
    using Dapper;
    using Npgsql;
    using System.Threading.Tasks;
    using Servicios.Interface.Persona;
    using System.Collections.Generic;

    public class Empleado : Persona
    {
        public Empleado()
        {

        }

        public override void Add(PersonaDto entidad)
        {
            try
            {
                var _db = new NpgsqlConnection("Server=localhost; User Id=postgres;Password=panchito; DataBase=SistemaVentas");

                var entidadNueva = (EmpleadoDto)entidad;

                string query = "INSERT INTO Persona(LocalidadId, Nombre, Apellido, Dni, Direccion, FechaRegistro, " +
                "Discriminador) VALUES(@Localidad, @Nombre, @Apellido, @Dni, @Direccion, @FechaRegistro, @Discriminador)";

                var parametros = new DynamicParameters();
                parametros.Add("@Localidad", entidadNueva.LocalidadId);
                parametros.Add("@Nombre", entidadNueva.Nombre);
                parametros.Add("@Apellido", entidadNueva.Apellido);
                parametros.Add("@Dni", entidadNueva.Dni);
                parametros.Add("@Direccion", entidadNueva.Direccion);
                parametros.Add("@FechaRegistro", System.DateTime.Now);
                parametros.Add("@Discriminador", "Empleado");

                _db.Execute(sql: query, param: parametros, commandType: System.Data.CommandType.Text);
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }

        public override IEnumerable<PersonaDto> Get()
        {
            using (var _db = new NpgsqlConnection("Server=localhost; User Id=postgres;Password=panchito; DataBase=SistemaVentas"))
            {
                try
                {
                    string query = "SELECT Persona.Id, Persona.LocalidadId, Persona.Nombre, Persona.Apellido, Persona.Dni, Persona.Direccion, Persona.Discriminador, Usuario.Nombre as NombreUsuario " +
                    "FROM Persona FULL OUTER JOIN Usuario ON Usuario.PersonaId = Persona.Id " +
                    "WHERE Discriminador = @Discriminador";

                    var parametro = new DynamicParameters();
                    parametro.Add("@Discriminador", "Empleado");

                    return _db.Query<EmpleadoDto>(sql: query, param: parametro,
                    commandType: System.Data.CommandType.Text);
                }
                catch (System.Exception e)
                {
                    throw new System.Exception(e.Message);
                }
            }
        }
    }
}