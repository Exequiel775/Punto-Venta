namespace Servicios.Implementacion.Provincias
{
    using Servicios.Interface.Provincias;
    using Dapper;
    using Npgsql;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Data;
    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly NpgsqlConnection _db;
        public ProvinciaServicio(NpgsqlConnection db)
        {
            _db = db;
        }
        public async Task<bool> Add(string provincia)
        {
            try
            {
                string query = "INSERT INTO Provincia(Descripcion) VALUES(@Descripcion)";

                var parametro = new DynamicParameters();
                parametro.Add("@Descripcion", provincia);

                await _db.ExecuteAsync(query, param: parametro, commandType: CommandType.Text);

                return true;
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                string query = "DELETE FROM Provincia WHERE Id = @ID";
                var parametro = new DynamicParameters();
                parametro.Add("@ID", id);
                await _db.ExecuteAsync(query, param: parametro, commandType: CommandType.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Provincia> GetById(long id)
        {
            string query = "SELECT * FROM Provincia WHERE Id = @ID";
            var parametro = new DynamicParameters();
            parametro.Add("@ID", id);

            return await _db.QueryFirstOrDefaultAsync<Provincia>(query, param: parametro, commandType: CommandType.Text);
        }

        public async Task<IEnumerable<Provincia>> GetProvincias()
        {
            string query = "SELECT * FROM Provincia";

            return await _db.QueryAsync<Provincia>(query, commandType: CommandType.Text);
        }

        public async Task<bool> Update(Provincia provincia)
        {
            try
            {
                string query = "UPDATE Provincia SET Descripcion = @Descripcion WHERE Id = @ID";
                var parametros = new DynamicParameters();
                parametros.Add("@Descripcion", provincia.Descripcion);
                parametros.Add("@ID", provincia.Id); 
                await _db.ExecuteAsync(query, param: parametros, commandType: CommandType.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}