namespace Servicios.Implementacion.Persona
{
    using Npgsql;
    using Dapper;
    using Servicios.Interface.Persona;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cliente : Persona
    {
        public override void Add(PersonaDto entidad)
        {
            try
            {
                using (var _db = new NpgsqlConnection("Server=localhost; User Id=postgres;Password=panchito; DataBase=SistemaVentas"))
                {
                    var entidadNueva = (ClienteDto)entidad;

                    string query = "INSERT INTO Persona(LocalidadId, Nombre, Apellido, Dni, Direccion, " +
                    "ActivarCtaCte, TieneLimite, FechaRegistro, LimiteMonto, Discriminador) " +
                    "VALUES(@Localidad, @Nombre, @Apellido, @Dni, @Direccion, @ActivarCta, @TieneLimite, " +
                    "@FechaRegistro, @Limite, @Discriminador)";

                    var parametros = new DynamicParameters();
                    parametros.Add("@Localidad", entidadNueva.LocalidadId);
                    parametros.Add("@Nombre", entidadNueva.Nombre);
                    parametros.Add("@Apellido", entidadNueva.Apellido);
                    parametros.Add("@Dni", entidadNueva.Dni);
                    parametros.Add("@Direccion", entidadNueva.Direccion);
                    parametros.Add("@ActivarCta", entidadNueva.ActivarCtaCte);
                    parametros.Add("@TieneLimite", entidadNueva.TieneLimite);
                    parametros.Add("@FechaRegistro", DateTime.Now);
                    parametros.Add("@Limite", decimal.Round(entidadNueva.LimiteMonto, 2));
                    parametros.Add("@Discriminador", "Cliente");

                    _db.Execute(sql: query, param: parametros, commandType: System.Data.CommandType.Text);
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override IEnumerable<PersonaDto> Get()
        {
            using (var _db = new NpgsqlConnection("Server=localhost; User Id=postgres;Password=panchito; DataBase=SistemaVentas"))
            {
                string query = "SELECT * FROM Persona WHERE Discriminador = @Discriminador";

                var parametro = new DynamicParameters();

                parametro.Add("@Discriminador", "Cliente");

                var clientes =  _db.Query<ClienteDto>(sql: query, param: parametro, commandType:
                System.Data.CommandType.Text);

                return clientes.Select(x => new ClienteDto
                {
                    Id = x.Id,
                    LocalidadId = x.LocalidadId,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Dni = x.Dni,
                    Direccion = x.Direccion,
                    ActivarCtaCte = x.ActivarCtaCte,
                    LimiteMonto = x.LimiteMonto,
                    TieneLimite = x.TieneLimite,
                    FechaRegistro = x.FechaRegistro
                }).ToList();
            }
        }

        public override PersonaDto GetById(long id)
        {
            using (var _db = new NpgsqlConnection("Server=localhost; User Id=postgres;Password=panchito; DataBase=SistemaVentas"))
            {
                string query = "SELECT * FROM Persona WHERE Id = @ID AND Discriminador = @Discriminador";

                var parametros = new DynamicParameters();
                parametros.Add("@ID", id);
                parametros.Add("@Discriminador", "Cliente");

                var cliente = _db.QueryFirstOrDefault<ClienteDto>(sql: query, param: parametros, commandType:
                System.Data.CommandType.Text);

                return new ClienteDto
                {
                    Id = cliente.Id,
                    LocalidadId = cliente.LocalidadId,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Dni = cliente.Dni,
                    Direccion = cliente.Direccion,
                    ActivarCtaCte = cliente.ActivarCtaCte,
                    TieneLimite = cliente.TieneLimite,
                    FechaRegistro = cliente.FechaRegistro,
                    LimiteMonto = cliente.LimiteMonto
                };
            }
        }
    }
}