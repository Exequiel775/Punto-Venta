namespace Servicios.Interface.Cliente
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IClienteServicio
    {
        Task<bool> Add(Cliente cliente);
        Task<bool> Update(Cliente clienteModificar);
        Task<bool> Delete(long id);
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetById(long id);  
        Task<bool> ActivarDesactivarCuenta(List<Cliente> clientes);
    }
}