namespace Servicios.Interface.Persona
{
    
    public class EmpleadoDto : PersonaDto
    {
        public string NombreUsuario { get; set; }
        public string Usuario => NombreUsuario ?? "NO CREADO";
    }
}