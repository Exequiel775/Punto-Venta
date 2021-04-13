namespace Servicios.Implementacion.Localidad
{
    using Servicios.Interface.Localidad;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dapper;
    using Npgsql;
    using System.Data;
    public class LocalidadServicio : ILocalidadServicio
    {
        private readonly NpgsqlConnection _db;
        public LocalidadServicio(NpgsqlConnection db)
        {
            _db = db;
        }

        public async Task<bool> Add(Localidad localidad)
        {
            try
            {
                string query = "INSERT INTO Localidad(ProvinciaId, Descripcion) VALUES(@Provincia, @Descripcion)";

                var parametros = new DynamicParameters();
                parametros.Add("@Provincia", localidad.ProvinciaId);
                parametros.Add("@Descripcion", localidad.Descripcion);

                await _db.ExecuteAsync(query, param: parametros, commandType: CommandType.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(long id)
        {
            string query = "DELETE FROM Localidad WHERE Id = @ID";
            var parametro = new DynamicParameters();
            parametro.Add("@ID", id);
            return await _db.ExecuteAsync(query, param: parametro, commandType: CommandType.Text) > 0;
        }

        public async Task<Localidad> GetById(long id)
        {
            try
            {
                string query = "SELECT * FROM Localidad WHERE Id = @ID";

                var parametro = new DynamicParameters();
                parametro.Add("@ID", id);

                return await _db.QueryFirstOrDefaultAsync<Localidad>(query, 
                param: parametro, commandType: CommandType.Text);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Localidad>> GetLocalidades()
        {
            string query = "SELECT Localidad.Id, Localidad.ProvinciaId, Localidad.Descripcion, Provincia.Descripcion AS Provincia FROM Localidad " + 
            "INNER JOIN Provincia ON Localidad.ProvinciaId = Provincia.Id ORDER BY Localidad.Descripcion ASC";

            return await _db.QueryAsync<Localidad>(query, commandType: CommandType.Text);
        }

        public async Task<IEnumerable<Localidad>> GetLocalidades(long provincia)
        {
            string query = "SELECT * FROM Localidad WHERE ProvinciaId = @Provincia";

            var parametro = new DynamicParameters();
            parametro.Add("@Provincia", provincia);

            return await _db.QueryAsync<Localidad>(query, param: parametro, commandType: CommandType.Text);
        }

        public async Task<bool> Update(Localidad localidad)
        {
            try
            {
                string query = "UPDATE Localidad SET " +
                "ProvinciaId = @Provincia, Descripcion = @Descripcion WHERE Id = @ID";

                var parametro = new DynamicParameters();
                parametro.Add("@Provincia", localidad.ProvinciaId);
                parametro.Add("@Descripcion", localidad.Descripcion);
                parametro.Add("@ID", localidad.Id);

                await _db.ExecuteAsync(query, param: parametro, commandType: CommandType.Text);

                return true;
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
}