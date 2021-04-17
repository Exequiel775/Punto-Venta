namespace Servicios.Implementacion.Marca
{
    using Servicios.Interface.Marca;
    using Dapper;
    using Npgsql;
    using System.Collections.Generic;

    public class MarcaServicio : IMarcaServicio
    {
        private readonly NpgsqlConnection _db;

        public MarcaServicio(NpgsqlConnection db)
        {
            _db = db;
        }
        public bool Add(string descripcion)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Marca> Get()
        {
            string query = "SELECT Id, Descripcion FROM Marca";

            return _db.Query<Marca>(sql: query, commandType: System.Data.CommandType.Text);
        }

        public Marca GetById(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}