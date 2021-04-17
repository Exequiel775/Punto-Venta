namespace Servicios.Interface.Marca
{
    using System.Collections.Generic;
    public interface IMarcaServicio
    {
        bool Add(string descripcion);
        IEnumerable<Marca> Get();
        Marca GetById(long id);
    }
}