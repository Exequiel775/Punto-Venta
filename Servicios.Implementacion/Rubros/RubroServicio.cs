namespace Servicios.Implementacion.Rubros
{
    using Servicios.Interface.Rubros;
    using Dapper;
    using Npgsql;
    using System.Collections.Generic;
    using System.Data;
    public class RubroServicio : IRubroServicio
    {
        private readonly NpgsqlConnection _db;

        public RubroServicio(NpgsqlConnection db)
        {
            _db = db;
        }
        public bool Add(string descripcion)
        {
            try
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Descripcion", descripcion);

                string query = "INSERT INTO Rubro(Descripcion) VALUES(@Descripcion)";

                _db.Execute(query, param: parametro, commandType: CommandType.Text);
                return true;
            }
            catch(System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }

        public Rubro GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Rubro> GetRubros()
        {
            try
            {
                string query = "SELECT * FROM Rubro";
                var rubros = _db.Query<Rubro>(query, commandType: CommandType.Text);
                return rubros;
            }
            catch(System.Exception e)
            {
             throw new System.Exception(e.Message);   
            }
        }
    }
}