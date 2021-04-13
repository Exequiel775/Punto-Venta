namespace Servicios.Interface.ListaPrecios
{
    using System.Collections.Generic;
    public interface IListaPrecioServicio
    {
        bool Add(ListaPrecio listaPrecio);
        bool Update(ListaPrecio listaPrecio);
        bool Delete(long id);
        IEnumerable<ListaPrecio> GetListaPrecios();
        ListaPrecio GetById(long id);
    }
}