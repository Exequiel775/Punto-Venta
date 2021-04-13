namespace Servicios.Interface.Rubros
{
    using System.Collections.Generic;
    public interface IRubroServicio
    {
        bool Add(string descripcion);
        IEnumerable<Rubro> GetRubros();
        Rubro GetById(long id);
    }
}