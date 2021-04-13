namespace Servicios.Interface.Articulos
{
    using System.Collections.Generic;
    public interface IArticuloServicio
    {
        void Add(Articulo articulo);
        IEnumerable<Articulo> Get();
        Articulo GetById(long id);
        ArticuloVentaDto GetByCodigo(int codigo, int listaPrecio);
        Articulo GetByCodigo(int codigo);
    }
}