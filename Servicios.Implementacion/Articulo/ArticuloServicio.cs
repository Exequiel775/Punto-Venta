namespace Servicios.Implementacion.Articulo
{
    using Servicios.Interface.Articulos;
    using Dapper;
    using System.Collections.Generic;
    using Npgsql;
    using System;
    using Servicios.Interface.Iva;
    using Servicios.Interface.ListaPrecios;
    public class ArticuloServicio : IArticuloServicio
    {
        private readonly NpgsqlConnection _db;
        private readonly IIvaServicio _ivaServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        public ArticuloServicio(NpgsqlConnection db, IIvaServicio ivaServicio, IListaPrecioServicio listaPrecioServicio)
        {
            _db = db;
            _ivaServicio = ivaServicio;
            _listaPrecioServicio = listaPrecioServicio;
        }
        public void Add(Articulo articulo)
        {
            try
            {
                var parametros = new DynamicParameters();
                parametros.Add("@IVA", articulo.IvaId);
                parametros.Add("@Rubro", articulo.RubroId);
                parametros.Add("@Marca", articulo.MarcaId);
                parametros.Add("@Codigo", articulo.Codigo);
                parametros.Add("@CodigoBarra", articulo.CodigoBarra);
                parametros.Add("@Descripcion", articulo.Descripcion);
                parametros.Add("@Stock", articulo.Stock);
                parametros.Add("@PrecioVenta", articulo.PrecioVenta);
                parametros.Add("@PrecioPublico", GenerarPrecioPublico(articulo.PrecioVenta));
                parametros.Add("@Foto", articulo.Foto);

                string query = "INSERT INTO Articulos(IvaId, RubroId, MarcaId, Codigo, CodigoBarra, Descripcion, " +
                    "Stock, PrecioVenta, PrecioPublico, Foto) VALUES(@IVA, @Rubro, @Marca, @Codigo, @CodigoBarra, " +
                    "@Descripcion, @Stock, @PrecioVenta, @PrecioPublico, @Foto)";

                _db.Execute(query, parametros, commandType: System.Data.CommandType.Text);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private decimal GenerarPrecioPublico(decimal precioVenta)
        {
            return decimal.Round(precioVenta + (precioVenta / 15));
        }

        public IEnumerable<Articulo> Get()
        {
            string query = "SELECT * FROM Articulos";
            return _db.Query<Articulo>(query, commandType: System.Data.CommandType.Text);
        }

        public Articulo GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ArticuloVentaDto GetByCodigo(int codigo, int listaPrecio)
        {
            
            var parametro = new DynamicParameters();
            parametro.Add("@Codigo", codigo);

            string query = "SELECT * FROM Articulos WHERE Codigo=@Codigo";

            var articuloEncontrado = _db.QueryFirstOrDefault<Articulo>(query, parametro, commandType: System.Data.CommandType.Text);

            if (articuloEncontrado != null)
            {
                var iva = _ivaServicio.GetById(articuloEncontrado.IvaId);
                var _listaPrecio = _listaPrecioServicio.GetById(listaPrecio);
                return new ArticuloVentaDto
                {
                    Id = articuloEncontrado.Id,
                    Codigo = articuloEncontrado.Codigo,
                    CodigoBarra = articuloEncontrado.CodigoBarra,
                    Descripcion = articuloEncontrado.Descripcion,
                    Stock = articuloEncontrado.Stock,
                    PrecioPublico = articuloEncontrado.PrecioPublico,
                    TotalIva = decimal.Round(articuloEncontrado.PrecioPublico / iva.Porcentaje, 2),
                    Total = decimal.Round(articuloEncontrado.PrecioPublico + (articuloEncontrado.PrecioPublico / iva.Porcentaje) + 
                    articuloEncontrado.PrecioPublico * _listaPrecio.Porcentaje / 100, 2)
                };
            }

            return null;
        }

        public Articulo GetByCodigo(int codigo)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Codigo", codigo);

            string query = "SELECT * FROM Articulos WHERE Codigo=@Codigo";

            var articuloEncontrado = _db.QueryFirstOrDefault<Articulo>(query, parametro, commandType: System.Data.CommandType.Text);

            if (articuloEncontrado != null)
            {
                return new Articulo
                {
                    Id = articuloEncontrado.Id,
                    Codigo = articuloEncontrado.Codigo,
                    CodigoBarra = articuloEncontrado.CodigoBarra,
                    Descripcion = articuloEncontrado.Descripcion,
                    Stock = articuloEncontrado.Stock,
                    PrecioPublico = articuloEncontrado.PrecioPublico
                };
            }

            return null;
        }
    } 
}