namespace Servicios.Implementacion.ListaPrecios
{
    using Servicios.Interface.ListaPrecios;
    using Dapper;
    using Npgsql;
    using System.Collections.Generic;

    public class ListaPrecioServicio : IListaPrecioServicio
    {
        private readonly NpgsqlConnection _db;

        public ListaPrecioServicio(NpgsqlConnection db)
        {
            _db = db;
        }
        public bool Add(ListaPrecio listaPrecio)
        {
            try
            {
                var parametros = new DynamicParameters();

                parametros.Add("@Descripcion", listaPrecio.Descripcion);
                parametros.Add("@Porcentaje", listaPrecio.Porcentaje);

                string query = "INSERT INTO ListaPrecios(Descripcion, Porcentaje) VALUES(@Descripcion, @Porcentaje)";
                _db.Execute(query, param: parametros, commandType: System.Data.CommandType.Text);

                return true;
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public ListaPrecio GetById(long id)
        {
            string query = "SELECT * FROM ListaPrecios WHERE Id = @ID";

            var parametro = new DynamicParameters();
            parametro.Add("@ID", id);
            return _db.QueryFirstOrDefault<ListaPrecio>(query, param: parametro, commandType: System.Data.CommandType.Text);
        }

        public IEnumerable<ListaPrecio> GetListaPrecios()
        {
            string query = "SELECT * FROM ListaPrecios";

            return _db.Query<ListaPrecio>(query, commandType: System.Data.CommandType.Text);
        }

        public bool Update(ListaPrecio listaPrecio)
        {
            throw new System.NotImplementedException();
        }
    }
}