namespace Servicios.Interface.Provincias
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IProvinciaServicio
    {
        Task<bool> Add(string descripcion);
        Task<bool> Update(Provincia provincia);
        Task<bool> Delete(long id);
        Task<IEnumerable<Provincia>> GetProvincias();
        Task<Provincia> GetById(long id);
    }
}