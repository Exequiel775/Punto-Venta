namespace Servicios.Interface.Persona
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    public interface IClienteServicio : IPersonaServicio
    {
        Task<bool> ActivarDesactivarCuenta(List<ClienteDto> clientes);
    }
}