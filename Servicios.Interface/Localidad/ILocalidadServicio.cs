namespace Servicios.Interface.Localidad
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ILocalidadServicio
    {
        Task<bool> Add(Localidad localidad);
        Task<bool> Update(Localidad localidad);
        Task<bool> Delete(long id);
        Task<IEnumerable<Localidad>> GetLocalidades();
        Task<IEnumerable<Localidad>> GetLocalidades(long provincia);
        Task<Localidad> GetById(long id);
    }
}