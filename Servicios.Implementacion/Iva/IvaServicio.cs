namespace Servicios.Implementacion.Iva
{
    using Servicios.Interface.Iva;
    using System.Collections.Generic;
    using Dapper;
    using Npgsql;
    public class IvaServicio : IIvaServicio
    {
        private readonly NpgsqlConnection _db;

        public IvaServicio(NpgsqlConnection db)
        {
            _db = db;
        }

        public IEnumerable<Iva> Get()
        {
            string query = "SELECT * FROM Iva";
            return _db.Query<Iva>(query, commandType: System.Data.CommandType.Text);
        }

        public Iva GetById(long id)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@ID", id);

            string query = "SELECT * FROM Iva WHERE Id=@ID";
            return _db.QueryFirstOrDefault<Iva>(query, parametro, commandType: System.Data.CommandType.Text);
        }
    }
}