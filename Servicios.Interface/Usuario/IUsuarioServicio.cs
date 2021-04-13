namespace Servicios.Interface.Usuario
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Servicios.Interface.Persona;
    public interface IUsuarioServicio
    {
        Task<bool> CrearUsuario(List<EmpleadoDto> empleados);
        Task<IEnumerable<Usuario>> Get();
        Task<bool> BloquearUsuarios(List<Usuario> usuarios);
        Task<bool> VerificarAcceso(string usuario, string password);
        Task<Usuario> GetByUser(string usuario);
        Task<bool> VerificarBloqueo(string usuario);
    }
}