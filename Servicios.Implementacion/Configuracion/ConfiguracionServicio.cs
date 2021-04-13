namespace Servicios.Implementacion.Configuracion
{
    using Dapper;
    using Npgsql;
    using Servicios.Interface.Configuracion;
    using System.Linq;
    public class ConfiguracionServicio : IConfiguracionServicio
    {
        private readonly NpgsqlConnection _db;

        public ConfiguracionServicio(NpgsqlConnection db)
        {
            _db = db;
        }
        public bool Add(Configuracion configuracion)
        {
            var obtenerConfiguracion = Get();

            if (obtenerConfiguracion != null)
            {
                string queryActualizar = "UPDATE Configuracion SET LocalidadId = @Localidad, " +
                "ListaPrecioPorDefectoId = @ListaPrecio, ClientePorDefectoId = @Cliente, RazonSocial = @RazonSocial, " +
                "Cuit = @Cuit, Telefono = @Telefono, Celular = @Celular, Email = @Email";

                var parametros = new DynamicParameters();
                parametros.Add("@Localidad", configuracion.LocalidadId);
                parametros.Add("@ListaPrecio", configuracion.ListaPrecioPorDefectoId);
                parametros.Add("@Cliente", configuracion.ClientePorDefectoId);
                parametros.Add("@RazonSocial", configuracion.RazonSocial);
                parametros.Add("@Cuit", configuracion.Cuit);
                parametros.Add("@Telefono", configuracion.Telefono);
                parametros.Add("@Celular", configuracion.Celular);
                parametros.Add("@Email", configuracion.Email);

                _db.Execute(sql: queryActualizar, param: parametros, commandType: System.Data.CommandType.Text);

                return true;
            }
            else
            {
                string queryGrabar = "INSERT INTO Configuracion(LocalidadId, ListaPrecioPorDefectoId, ClientePorDefectoId, RazonSocial, " +
                "Cuit, Telefono, Celular, Email) VALUES(@Localidad, @ListaPrecio, @Cliente, @RazonSocial, @Cuit, " +
                "@Telefono, @Celular, @Email)";

                var parametrosGrabar = new DynamicParameters();
                parametrosGrabar.Add("@Localidad", configuracion.LocalidadId);
                parametrosGrabar.Add("@ListaPrecio", configuracion.ListaPrecioPorDefectoId);
                parametrosGrabar.Add("@Cliente", configuracion.ClientePorDefectoId);
                parametrosGrabar.Add("@RazonSocial", configuracion.RazonSocial);
                parametrosGrabar.Add("@Cuit", configuracion.Cuit);
                parametrosGrabar.Add("@Telefono", configuracion.Telefono);
                parametrosGrabar.Add("@Celular", configuracion.Celular);
                parametrosGrabar.Add("@Email", configuracion.Email);

                _db.Execute(sql: queryGrabar, param: parametrosGrabar, commandType: System.Data.CommandType.Text);

                return true;
            }
        }

        public Configuracion Get()
        {
            string query = "SELECT Configuracion.Id, Configuracion.LocalidadId, Configuracion.ListaPrecioPorDefectoId, Configuracion.ClientePorDefectoId, " +
            "Configuracion.RazonSocial, Configuracion.Cuit, Configuracion.Telefono, Configuracion.Celular, Configuracion.Email, " + 
            "Localidad.Descripcion AS LocalidadDescripcion FROM Configuracion " +
            "INNER JOIN Localidad ON Configuracion.LocalidadId = Localidad.Id";

            return _db.QueryFirstOrDefault<Configuracion>(sql: query, commandType: System.Data.CommandType.Text);
        }
    }
}