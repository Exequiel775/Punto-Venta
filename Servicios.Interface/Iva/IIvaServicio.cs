namespace Servicios.Interface.Iva
{
    using System.Collections.Generic;
    public interface IIvaServicio
    {
        IEnumerable<Iva> Get();
        Iva GetById(long id);
    }
}